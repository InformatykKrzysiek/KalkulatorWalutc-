using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonwerterWalutowy.Views
{
    /// <summary>
    /// Interaction logic for KonwerterView.xaml
    /// </summary>
    /// DataBaseUpdate _dataBaseUpdate = new DataBaseUpdate();
    public partial class KonwerterView 
    {
        DataBaseUpdate _dataBaseUpdate = new DataBaseUpdate();
        GetFromDB _fromDb = new GetFromDB();
        private decimal fromValue;
        private string fromExchange;
        private decimal toValue;
        private string toExchange;
        private string day = "latest";
        private string calendarDay = "latest";
       
        Regex regex = new Regex(@"^[0-9]{0,6}(\.[0-9]{1,2})?$");

        public KonwerterView()
        {
            InitializeComponent();
            bindListBox();
        }

        public void DayChange(string newDay = "latest")
        {
            day = newDay;
        }


        private string[] exchangeNames =
        {
            "CAD", "HKD", "ISK", "PHP", "DKK", "HUF", "CZK",
            "AUD", "RON", "SEK", "IDR", "INR", "BRL", "RUB", "HRK",
            "JPY", "THB", "CHF", "SGD", "PLN", "BGN", "TRY", "CNY",
            "NOK", "NZD", "ZAR", "USD", "MXN", "ILS", "GBP", "KRW", "MYR", "EUR"
        };

        private void bindListBox()
        {
            ListBoxTo.ItemsSource = exchangeNames;
            ListBoxFrom.ItemsSource = exchangeNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fromExchange != null && toExchange != null)
            {
                if (regex.IsMatch(toCount.Text))
                {


                    if (fromExchange == "EUR" && toExchange != "EUR")
                    {
                        fromValue = 1;
                        toValue = _fromDb.Get(day, toExchange);

                    }

                    if (toExchange == "EUR" && fromExchange != "EUR")
                    {
                        fromValue = _fromDb.Get(day, fromExchange);
                        toValue = 1;

                    }

                    if (toExchange == "EUR" && fromExchange == "EUR")
                    {
                        fromValue = 1;
                        toValue = 1;
                    }

                    if (toExchange != "EUR" && fromExchange != "EUR")
                    {
                        fromValue = _fromDb.Get(day, fromExchange);
                        toValue = _fromDb.Get(day, toExchange);
                    }

                    decimal counteDecimal = decimal.Parse(toCount.Text.Replace(".", ",")) / fromValue * toValue;
                    counteDecimal = decimal.Round(counteDecimal, 2);
                    Counted.Text =
                        $"  {counteDecimal} {toExchange}";
                }
                else MessageBox.Show("Niepoprawne dane");
            }
            else MessageBox.Show("Wybierz dwie waluty");
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
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
            //var str = ExchangeRatesApiServices.GetRates(TextBox.Text);
            // Label.Content = _exchangeRatesApiServices.GetRates(Calendar.SelectedDate.Value.Date.ToString("yyyy-MM-dd"));
            // = Calendar.SelectedDate.Value.Date.ToString("yyyy-MM-dd");

            _dataBaseUpdate.update(calendarDay);
            DayChange(calendarDay);
        }

        private void ListBoxFrom_OnSelected(object sender, RoutedEventArgs e)
        {
            fromExchange = ListBoxFrom.SelectedItem.ToString();
        }

        private void ListBoxTo_OnSelected(object sender, RoutedEventArgs e)
        {
            toExchange = ListBoxTo.SelectedItem.ToString();
        }
    }
}