using OfficeOpenXml;
using System.Windows;

namespace CoinMarketCapApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 设置ExcelPackage的LicenseContext为Commercial
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // 这之后你可以在应用程序中使用EPPlus库，它将遵循商业许可证要求
        }
    }
}