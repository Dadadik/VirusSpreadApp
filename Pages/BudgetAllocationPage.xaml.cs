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
    /// Логика взаимодействия для BudgetAllocationPage.xaml
    /// </summary>
    public partial class BudgetAllocationPage : Page
    {
        public BudgetAllocationPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            VirusSpreadEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridBudgetAllocation.ItemsSource = VirusSpreadEntities.GetContext().BudgetAllocations.ToList();
           

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditBudgetAllocation addOrEditBudgetAllocation = new AddOrEditBudgetAllocation(null);
            addOrEditBudgetAllocation.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBudgetAllocation.SelectedItem is BudgetAllocation budgetAllocation)
            {
                AddOrEditBudgetAllocation addOrEditBudgetAllocation = new AddOrEditBudgetAllocation(budgetAllocation);
                addOrEditBudgetAllocation.Show();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {

            if (DataGridBudgetAllocation.SelectedItem is BudgetAllocation budgetAllocation)
            {
                try

                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        VirusSpreadEntities.GetContext().BudgetAllocations.Remove(budgetAllocation);
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
