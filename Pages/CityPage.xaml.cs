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
using ViruseSpreadApp.Entities;
using ViruseSpreadApp.Windows;




namespace ViruseSpreadApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CityPage.xaml
    /// </summary>
    public partial class CityPage : Page
    {
       
        public CityPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            VirusSpreadEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridCity.ItemsSource = VirusSpreadEntities.GetContext().Cities.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditCity addOrEditCity = new AddOrEditCity(null);
            addOrEditCity.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridCity.SelectedItem is City city)
            {
                AddOrEditCity addOrEditCity = new AddOrEditCity(city);
                addOrEditCity.Show();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
           
            if(DataGridCity.SelectedItem is City city)
            {
                try
                    
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись","Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        VirusSpreadEntities.GetContext().Cities.Remove(city);
                        VirusSpreadEntities.GetContext().SaveChanges();
                        Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
                        MessageBox.Show("Запись удалена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        
    }
}
