using CoinMarketCapApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinMarketCapApp.Controls
{
    /// <summary>
    /// PaginationControl.xaml 的交互逻辑
    /// </summary>
    public partial class PaginationControl : UserControl
    {
        public PaginationControl()
        {
            InitializeComponent();
        }


        public object DataContext
        {
            get { return this.GetValue(DataContextProperty); }
            set { this.SetValue(DataContextProperty, value); }
        }

        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(object), typeof(PaginationControl), new PropertyMetadata(null));


        //public int CurrentPage
        //{
        //    get { return int.Parse(currentPageTextBox.Text); }
        //    set { currentPageTextBox.Text = value.ToString(); }
        //}

        //public int TotalPages
        //{
        //    get { return int.Parse(totalPagesTextBlock.Text); }
        //    set { totalPagesTextBlock.Text = value.ToString(); }
        //}

        //private void PreviousButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (CurrentPage > 1)
        //    {
        //        CurrentPage--;
        //    }
        //}

        //private void NextButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (CurrentPage < TotalPages)
        //    {
        //        CurrentPage++;
        //    }
        //}
    }
}
