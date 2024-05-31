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
    /// Логика взаимодействия для PossibleStrategyPage.xaml
    /// </summary>
    public partial class PossibleStrategyPage : Page
    {
        public PossibleStrategyPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            VirusSpreadEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridPossibleStrategy.ItemsSource = VirusSpreadEntities.GetContext().PossibleStrategies.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditPossibleStrategy addOrEditPossibleStrategy = new AddOrEditPossibleStrategy(null);
            addOrEditPossibleStrategy.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPossibleStrategy.SelectedItem is PossibleStrategy possibleStrategy)
            {
                AddOrEditPossibleStrategy addOrEditPossibleStrategy = new AddOrEditPossibleStrategy(possibleStrategy);
                addOrEditPossibleStrategy.Show();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPossibleStrategy.SelectedItem is PossibleStrategy possibleStrategy)
            {
                try

                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        VirusSpreadEntities.GetContext().PossibleStrategies.Remove(possibleStrategy);
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

