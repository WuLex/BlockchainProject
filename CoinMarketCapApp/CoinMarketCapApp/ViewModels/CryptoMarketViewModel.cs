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
using System.Windows.Markup;
using OfficeOpenXml;
using System.IO;
using System.Collections;

namespace CoinMarketCapApp.ViewModels
{
    public class CryptoMarketViewModel : INotifyPropertyChanged 
    {

        // 排序命令和分页命令
        public ICommand SortCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        public ICommand ExportToExcelCommand { get; } // 导出到Excel命令

        public ListSortDirection SortDirection { get; set; } = ListSortDirection.Ascending; // 列表排序方向，默认升序
        private string currentSortColumn { get; set; } = ""; // 当前排序列

        private ObservableCollection<CryptoCoin> coins; // 用于显示的加密货币列表
        public ObservableCollection<CryptoCoin> Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                OnPropertyChanged(nameof(Coins)); // 属性更改通知
            }
        }

        private Pagination<CryptoCoin> pagedCoins; // 分页后的加密货币列表
        public Pagination<CryptoCoin> PagedCoins
        {
            get { return pagedCoins; }
            set
            {
                pagedCoins = value;
                OnPropertyChanged(nameof(PagedCoins)); // 属性更改通知
            }
        }

        private int currentPage = 1; // 当前页数，默认为1
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage)); // 属性更改通知
            }
        }

        private int totalPages; // 总页数
        public int TotalPages
        {
            get { return totalPages; }
            set
            {
                totalPages = value;
                OnPropertyChanged(nameof(TotalPages)); // 属性更改通知
            }
        }

        // 加载数据的方法
        private void LoadData()
        {
            ICoinmarketcapClient client = new CoinmarketcapClient("41947fa6-****-****-****-f316cfd33db3"); // 使用 Coinmarketcap 客户端

            //指定要返回的结果数。使用此参数和“start”参数来确定您自己的分页大小。
            //默认是100,最大值为5000
            var currencyList = client.GetCurrencies(5000); // 获取加密货币数据
            if (currencyList != null)
            {
                foreach (var cryptoData in currencyList)
                {
                    var coin = new CryptoCoin
                    {
                        Name = cryptoData.Name,
                        Price = cryptoData.Price,
                        Symbol = cryptoData.Symbol,
                        CmcRank= Convert.ToInt32(cryptoData.Rank.Trim()??"-1"),
                        LaunchedDate = cryptoData.DateAdded // 假设 API 响应中有 DateAdded 属性
                    };

                    Coins.Add(coin); // 添加加密货币数据到列表
                }
            }
        }

        // 构造函数
        public CryptoMarketViewModel()
        {
            Coins = new ObservableCollection<CryptoCoin>(); // 初始化加密货币列表
            SortCommand = new RelayCommand(SortCoinsByColumn); // 初始化排序命令
            NextPageCommand = new RelayCommand((p) =>
            {
                NextPage(); // 初始化下一页命令
            });
            PreviousPageCommand = new RelayCommand((p) =>
            {
                PreviousPage(); // 初始化上一页命令
            });

            ExportToExcelCommand = new RelayCommand((p) =>
            {
                ExportToExcel(); // 初始化导出到 Excel 命令
            });
            LoadData(); // 加载加密货币数据
            UpdatePagedCoins(); // 初始化分页数据
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // 属性更改通知事件
        }

        // 根据列排序加密货币
        public void SortCoinsByColumn(object parameter)
        {
            string column = parameter as string;
            if (column != null)
            {
                if (column == currentSortColumn)
                {
                    SortDirection = (SortDirection == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
                }
                else
                {
                    currentSortColumn = column;
                    SortDirection = ListSortDirection.Ascending;
                }
                IEnumerable<CryptoCoin> sortedCoins;
                if (SortDirection == ListSortDirection.Ascending)
                {
                    sortedCoins = new ObservableCollection<CryptoCoin>(Coins.OrderBy(c => c.GetType().GetProperty(column).GetValue(c, null)));
                }
                else
                {
                    sortedCoins = new ObservableCollection<CryptoCoin>(Coins.OrderByDescending(c => c.GetType().GetProperty(column).GetValue(c, null)));
                }

                Coins = new ObservableCollection<CryptoCoin>(sortedCoins); // 更新排序后的列表
                UpdatePagedCoins();
            }
        }

        // 更新分页后的加密货币列表
        private void UpdatePagedCoins()
        {
            int pageSize = 10; // 每页显示的项数

            var pagedData = Coins.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            TotalPages = (int)Math.Ceiling((double)Coins.Count / pageSize);

            PagedCoins = new Pagination<CryptoCoin>
            {
                //Items = new ObservableCollection<CryptoCoin>(pagedData),
                Items = pagedData,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PageSize = pageSize
            };
        }

        // 下一页操作
        private void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                UpdatePagedCoins();
            }
        }

        // 上一页操作
        private void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdatePagedCoins();
            }
        }

        // 检查是否可以导出到 Excel
        public bool CanExportToExcel()
        {
            return Coins != null && Coins.Any();
        }

        /// <summary>
        /// 导出数据到 Excel 的方法，使用第三方库来完成导出操作
        /// </summary>
        public void ExportToExcel()
        {
            if (CanExportToExcel())
            {
                // 创建文件保存对话框
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save Excel File";

                // 显示文件保存路径选择框
                bool? result = saveFileDialog.ShowDialog();

                if (result == true)
                {
                    string filePath = saveFileDialog.FileName;
                    try
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                            // 添加列头
                            worksheet.Cells[1, 1].Value = "名称";
                            worksheet.Cells[1, 2].Value = "价格";
                            worksheet.Cells[1, 3].Value = "市值排名";
                            worksheet.Cells[1, 4].Value = "代码符号";
                            worksheet.Cells[1, 5].Value = "添加时间";
                            // 设置列头字体加粗
                            worksheet.Cells[1, 1, 1, 5].Style.Font.Bold = true;

                            // 添加数据到工作表
                            for (int i = 0; i < Coins.Count; i++)
                            {
                                worksheet.Cells[i + 2, 1].Value = Coins[i].Name;
                                worksheet.Cells[i + 2, 2].Value = Coins[i].Price;
                                worksheet.Cells[i + 2, 3].Value = Coins[i].CmcRank;
                                worksheet.Cells[i + 2, 4].Value = Coins[i].Symbol;
                                worksheet.Cells[i + 2, 5].Value = Coins[i].LaunchedDate.ToString("yyyy-MM-dd HH:mm:ss");
                                // 添加更多属性
                            }

                            // 保存 Excel 文件到用户选择的路径
                            File.WriteAllBytes(filePath, package.GetAsByteArray());

                            // 显示保存成功提示
                            MessageBox.Show("Excel 文件保存成功。", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        // 显示错误提示
                        MessageBox.Show("保存 Excel 文件时发生错误：" + ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
