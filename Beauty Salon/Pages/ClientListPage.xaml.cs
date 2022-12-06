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

namespace Beauty_Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public ClientListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateClients();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddEditClient());
        }


        private void UpdateClients()
        {
            var clients = App.Context.Clients.ToList();

            DGclient.ItemsSource = clients;
        }

        private void ImgEdit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentClient = (sender as Image).DataContext as Entities.Client;
            NavigationService.Navigate(new Pages.AddEditClient(currentClient));
        }

        private void ImgDelete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentClient = (sender as Image).DataContext as Entities.Client;

            if (MessageBox.Show($"Вы уверены, что хотите удалить клиента: " + $"{currentClient.LastName}?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Clients.Remove(currentClient);
                App.Context.SaveChanges();
            }
        }
    }
}
