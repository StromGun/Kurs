﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Page
    {
        private Entities.Client _currentClient = null;
        private byte[] _mainImageData;
        public AddEditClient()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
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
    }
}
