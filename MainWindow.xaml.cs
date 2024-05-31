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
using ViruseSpreadApp.Pages;
using ViruseSpreadApp.Entities;


namespace ViruseSpreadApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new CityPage();

        }

        private void BtnCity_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CityPage();
        }

        private void BtnPossibleStrategy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PossibleStrategyPage();
        }

        private void BtnBudgetAllocation_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new BudgetAllocationPage();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
