using CoinMarketCapApp.Models;
using NoobsMuc.Coinmarketcap.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace CoinMarketCapApp.ViewModels
{
    public class CryptoMarketViewModel : INotifyPropertyChanged
    {
        public ICommand SortCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        private bool sortAscending = true;

        private ObservableCollection<CryptoCoin> coins;
        public ObservableCollection<CryptoCoin> Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                OnPropertyChanged(nameof(Coins));
            }
        }
 
        private Pagination<CryptoCoin> pagedCoins;
        public Pagination<CryptoCoin> PagedCoins
        {
            get { return pagedCoins; }
            set
            {
                pagedCoins = value;
                OnPropertyChanged(nameof(PagedCoins));
            }
        }


        private int currentPage = 1; // 当前页数，默认为1
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                //UpdatePagedCoins(); // 当页数改变时，更新分页数据
            }
        }

        private int totalPages; // 总页数
        public int TotalPages
        {
            get { return totalPages; }
            set
            {
                totalPages = value;
                OnPropertyChanged(nameof(TotalPages));
            }
        }


        private void LoadData()
        {
            ICoinmarketcapClient client = new CoinmarketcapClient("41947fa6-*******-487c-8815-***********");
 
            var currencyList = client.GetCurrencies();
            if (currencyList != null)
            {
                foreach (var cryptoData in currencyList)
                {
                    var coin = new CryptoCoin
                    {
                        Name = cryptoData.Name,
                        Price = cryptoData.Price,
                        Symbol = cryptoData.Symbol,
                        LaunchedDate = cryptoData.DateAdded // 此处假设API响应中有一个名为DateAdded的属性
                    };

                    Coins.Add(coin);
                }
            }

        }

        public CryptoMarketViewModel()
        {
            Coins = new ObservableCollection<CryptoCoin>();
            SortCommand = new RelayCommand(SortCoinsByColumn);
            //NextPageCommand = new RelayCommand(NextPage);
            //PreviousPageCommand = new RelayCommand(PreviousPage);
            NextPageCommand = new RelayCommand((p) =>
            {
                NextPage(); // 执行命令的操作，不需要参数
            });
            PreviousPageCommand = new RelayCommand((p) =>
            {
                PreviousPage(); // 执行命令的操作，不需要参数
            });

            LoadData();
            UpdatePagedCoins(); // 在构造函数中初始化分页数据
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SortCoinsByColumn(object parameter)
        {
            string column = parameter as string;
            if (column != null)
            {
                if (sortAscending)
                {
                    Coins = new ObservableCollection<CryptoCoin>(Coins.OrderBy(c => c.GetType().GetProperty(column).GetValue(c, null)));
                }
                else
                {
                    Coins = new ObservableCollection<CryptoCoin>(Coins.OrderByDescending(c => c.GetType().GetProperty(column).GetValue(c, null)));
                }

                sortAscending = !sortAscending;
            }
        }

        private void UpdatePagedCoins()
        {
            int pageSize = 10; // 每页显示的项数

            var pagedData = Coins.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            TotalPages = (int)Math.Ceiling((double)Coins.Count / pageSize);

            PagedCoins = new Pagination<CryptoCoin>
            {
                Items = new ObservableCollection<CryptoCoin>(pagedData),
                CurrentPage = CurrentPage, // 使用属性中的值而不是字段
                TotalPages = TotalPages,
                PageSize = pageSize
            };
        }

        private void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                UpdatePagedCoins();
            }
        }

        private void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdatePagedCoins();
            }
        }
    }
}
