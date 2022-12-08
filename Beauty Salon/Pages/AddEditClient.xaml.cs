using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Beauty_Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Page
    {
        private Entities.Client _currentClient = null;
        private byte[] _mainImageData;

        public AddEditClient()
        {
            InitializeComponent();
            DataContext = new Entities.Client();
        }

        public AddEditClient(Entities.Client client)
        {
            InitializeComponent();
            DataContext = client;
            _currentClient = client;
            Title = "Редактировать данные о клиенте";
            TboxLname.Text = _currentClient.LastName;
            TboxFname.Text = _currentClient.FirstName;
            TboxPatronymic.Text = _currentClient.Patronymic;
            TboxAge.Text = _currentClient.Age.ToString();

            if (_currentClient.Image != null)
                ClientImage.Source = (ImageSource) new ImageSourceConverter().ConvertFrom(_currentClient.Image);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = ErrorCheck();

            if (errorMessage.Length > 0 )
            {
                MessageBox.Show(errorMessage,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        Age = short.Parse(TboxAge.Text),
                        Image = _mainImageData
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
                    if (_mainImageData != null)
                        _currentClient.Image = _mainImageData;
                    App.Context.SaveChanges();
                }
                NavigationService.GoBack();
            }

        }

        private void BtnSelectImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ClientImage.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
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
            if (short.TryParse(TboxAge.Text, out age) == false || age <= 0 || age >=200)
                errorBuilder.AppendLine("Возраст должен быть положительным числом и не больше 200");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
    }
}
