using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Beauty_Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            UpdateServices();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void UpdateServices()
        {
            var service = App.Context.Services.ToList();

            DGservice.ItemsSource = service;
        }

        private void ImgEdit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentService = (sender as Image).DataContext as Entities.Service;
            NavigationService.Navigate(new Pages.AddEditServicePage(currentService));
            UpdateServices();
        }

        private void ImgDelete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentService = (sender as Image).DataContext as Entities.Service;

            if (MessageBox.Show($"Вы уверены, что хотите удалить услугу: " + $"{currentService.Name}?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Services.Remove(currentService);
                App.Context.SaveChanges();
            }
            UpdateServices();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddEditServicePage());
            UpdateServices();
        }   
    }
}
