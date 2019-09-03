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
using System.Windows.Threading;
using KonwerterWalutowy.ViewModels;

namespace KonwerterWalutowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // ExchangeRatesApiServices _exchangeRatesApiServices = new ExchangeRatesApiServices();
        DataBaseUpdate _dataBaseUpdate = new DataBaseUpdate();
        public MainWindow()
        {
            InitializeComponent();
            _dataBaseUpdate.update();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            clock.Content = DateTime.Now.ToLongTimeString();
            date.Content = DateTime.Now.ToLongDateString();
        }
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BarGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
               DispatcherTimer dispatcherTimer = new DispatcherTimer();
               dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
               dispatcherTimer.Tick += Timer_Tick;
               dispatcherTimer.Start();
        }

        private void Konwerter_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new KonwerterViewModel();
        }

        private void Archiwum_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ArchiwumViewModel();
        }
    }
}
