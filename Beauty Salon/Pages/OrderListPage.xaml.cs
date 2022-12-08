﻿using System;
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
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public OrderListPage()
        {
            InitializeComponent();
            UpdateOrders();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOrders();
        }

        private void UpdateOrders()
        {
            var orders = App.Context.Orders.ToList();
            var orderService = App.Context.OrderServices.ToList();

            DGorders.ItemsSource = orders;
            DGorders.DataContext = orderService;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditOrderPage());
            UpdateOrders();
        }

        private void ImgDelete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentOrder = (sender as Image).DataContext as Entities.Order;

            if (MessageBox.Show($"Вы уверены, что хотите удалить клиента: " + $"{currentOrder.OrderName}?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Orders.Remove(currentOrder);
                App.Context.SaveChanges();
            }
            UpdateOrders();
        }

        private void ImgEdit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UpdateOrders();
        }
    }
}