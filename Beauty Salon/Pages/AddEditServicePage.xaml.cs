using Beauty_Salon.Entities;
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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Entities.Service currentService = null;
        public AddEditServicePage()
        {
            InitializeComponent();
            DataContext = new Service();
        }

        public AddEditServicePage(Entities.Service service)
        {
            InitializeComponent();
            DataContext = service;
            currentService = service;
            Title = "Редактировать услугу";
            TboxName.Text = currentService.Name;
            TboxPrice.Text = currentService.Price.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckError();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (currentService == null)
                {
                    var service = new Service()
                    {
                        Name = TboxName.Text,
                        Price = int.Parse(TboxPrice.Text)
                    };
                    App.Context.Services.Add(service);
                    App.Context.SaveChanges();
                }
                else
                {
                    currentService.Name = TboxName.Text;
                    currentService.Price = int.Parse(TboxName.Text);
                    App.Context.SaveChanges();
                }
                NavigationService.GoBack();
            }
        }


        private string CheckError()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrEmpty(TboxName.Text))
                errorBuilder.AppendLine("Название услуги обязательно для заполнения");

            var serviceFromDB = App.Context.Services.ToList()
            .FirstOrDefault(p => p.Name.ToLower() == TboxName.Text.ToLower());
            if (serviceFromDB != null)
                errorBuilder.AppendLine("Такая услуга уже есть в базе данных");

            decimal cost = 0;
            if (decimal.TryParse(TboxPrice.Text, out cost) == false || cost <= 0)
                errorBuilder.AppendLine("Стоимость услуги должна быть положительным числом");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();

        }

    }
}
