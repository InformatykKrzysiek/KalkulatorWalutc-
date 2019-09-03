using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
using KonwerterWalutowy.ViewModels;
using RestSharp.Extensions;

namespace KonwerterWalutowy.Views
{
    /// <summary>
    /// Interaction logic for ArchiwumView.xaml
    /// </summary>
    public partial class ArchiwumView : UserControl
    {
        //ExchangeRatesApiServices _exchangeRatesApiServices = new ExchangeRatesApiServices();
        DataBaseUpdate _dataBaseUpdate = new DataBaseUpdate();
        GetFromDB _fromDb = new GetFromDB();
        //private List<string> itemsList;
        private string calendarDay = "latest";

        private DataTable table;
        //private IEnumerable<string> itemsEnumerable;
        private decimal tempDecimal;
        public ArchiwumView()
        {
            InitializeComponent();
        }
        private string[] exchangeNames =
        {
            "CAD", "HKD", "ISK", "PHP", "DKK", "HUF", "CZK",
            "AUD", "RON", "SEK", "IDR", "INR", "BRL", "RUB", "HRK",
            "JPY", "THB", "CHF", "SGD", "PLN", "BGN", "TRY", "CNY",
            "NOK", "NZD", "ZAR", "USD", "MXN", "ILS", "GBP", "KRW", "MYR"
        };
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //var str = ExchangeRatesApiServices.GetRates(TextBox.Text);
            // Label.Content = _exchangeRatesApiServices.GetRates(Calendar.SelectedDate.Value.Date.ToString("yyyy-MM-dd"));
            // = Calendar.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            ArchiwumList.Items.Clear();
            if (Calendar.Text != "")
            {


                if (Calendar.Text.Contains("Saturday"))
                {
                    calendarDay = Calendar.SelectedDate.Value.AddDays(-1).ToString();
                }

                if (Calendar.Text.Contains("Sunday"))
                {
                    calendarDay = Calendar.SelectedDate.Value.AddDays(-2).ToString();
                }
                else
                {
                    calendarDay = Calendar.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
                }
            }

            _dataBaseUpdate.update(calendarDay);
                foreach (var name in exchangeNames)
                {
                    tempDecimal = _fromDb.Get(calendarDay, name);
                    //table.
                    ArchiwumList.Items.Add($" {decimal.Round(tempDecimal, 2)}   {name}");
                    // .Add($"{tempDecimal} {name}");
                }
            
        }
    }
}
