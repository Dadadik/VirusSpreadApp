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
using System.Windows.Shapes;
using ViruseSpreadApp.Entities;
using ViruseSpreadApp.Pages;

namespace ViruseSpreadApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditCity.xaml
    /// </summary>
    public partial class AddOrEditCity : Window
    {
        private City _currentCity = new City();
        private int Population = 0, PercentInfected = 0, PercentVaccinated = 0;
        private double VaccinationPrice = 0;
        public AddOrEditCity(City city)
        {
            InitializeComponent();

            if (city != null)
                _currentCity = city;
            DataContext = _currentCity;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentCity.Id == 0)
                    VirusSpreadEntities.GetContext().Cities.Add(_currentCity);
                VirusSpreadEntities.GetContext().SaveChanges();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private StringBuilder CheckField()
        {
            StringBuilder str = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentCity.CityName))
                str.AppendLine("Поле название города введено некорректно");
            if (!int.TryParse(TbPopulation.Text, out Population))
                str.AppendLine("Поле население только число");
            else if (Population <= 0)
                str.AppendLine("Население не может быть отрицательным");
            

            if (!int.TryParse(TbPercentInfected.Text, out PercentInfected))
                str.AppendLine("Поле процент заболевших только число");           
            if (!int.TryParse(TbPercentVaccinated.Text, out PercentVaccinated))
                str.AppendLine("Поле процент вакцинированных только число");          
            if (!double.TryParse(TbVaccinationPrice.Text, out VaccinationPrice))
                str.AppendLine("Поле cтоимость прививки только число");
            else if (VaccinationPrice <= 0)
                str.AppendLine("Неверная цена прививки");
            return str;
        }
    }
}

