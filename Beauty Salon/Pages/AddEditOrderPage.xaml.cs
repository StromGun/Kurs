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
    /// Логика взаимодействия для AddEditOrderPage.xaml
    /// </summary>
    public partial class AddEditOrderPage : Page
    {
        Entities.Client _currentClient = null;
        Entities.Order _currentOrder = null;

        public AddEditOrderPage()
        {
            InitializeComponent();
            DataContext = new Entities.Order();
            DataContext = new Entities.Client();
            LboxService.ItemsSource = App.Context.Services.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = ErrorCheck();

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (_currentClient == null)
                {
                    var client = new Entities.Client
                    {
                        LastName = TboxLname.Text,
                        FirstName = TboxFname.Text,
                        Patronymic = TboxPatronymic.Text,
                        Age = short.Parse(TboxAge.Text)
                    };
                    App.Context.Clients.Add(client);
                    App.Context.SaveChanges();
                }
                else
                {
                    _currentClient.LastName = TboxLname.Text;
                    _currentClient.FirstName = TboxFname.Text;
                    _currentClient.Patronymic = TboxPatronymic.Text;
                    _currentClient.Age = short.Parse(TboxAge.Text);

                    _currentOrder.OrderName = DateTime.Now.ToString() + _currentClient.ID.ToString();
                    //foreach (var item in LboxService.SelectedItems)
                    //{
                    //    _currentOrder.OrderServices = item.ToString();
                    //}
                    App.Context.SaveChanges();
                }
                NavigationService.GoBack();
            }
        }


        private string ErrorCheck()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TboxLname.Text))
                errorBuilder.AppendLine("Фамилия обязательня для заполнения");
            if (string.IsNullOrWhiteSpace(TboxFname.Text))
                errorBuilder.AppendLine("Имя обязательня для заполнения");

            short age = 0;
            if (short.TryParse(TboxAge.Text, out age) == false || age <= 0 || age >= 200)
                errorBuilder.AppendLine("Возраст должен быть положительным числом и не больше 200");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
    }
}