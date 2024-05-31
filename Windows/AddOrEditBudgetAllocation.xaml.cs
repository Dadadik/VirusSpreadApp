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
using ViruseSpreadApp.Pages;
using ViruseSpreadApp.Entities;

namespace ViruseSpreadApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditBudgetAllocation.xaml
    /// </summary>
    public partial class AddOrEditBudgetAllocation : Window
    {
        private double Payment = 0;
       
        private BudgetAllocation _currentBudgetAllocation;

        public AddOrEditBudgetAllocation(BudgetAllocation budgetAllocation)
        {
            InitializeComponent();
            if (budgetAllocation != null)
            {
                _currentBudgetAllocation = budgetAllocation;
                DataContext = _currentBudgetAllocation;
                ComboBoxCityName.ItemsSource = VirusSpreadEntities.GetContext().BudgetAllocations.ToList();
                ComboBoxPossibleStrategyName.ItemsSource = VirusSpreadEntities.GetContext().BudgetAllocations.ToList();
            }
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
                if (_currentBudgetAllocation.Id == 0)
                    VirusSpreadEntities.GetContext().BudgetAllocations.Add(_currentBudgetAllocation);
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
            if (ComboBoxCityName.SelectedItem == null)
                str.AppendLine("выберите город");
            if (ComboBoxPossibleStrategyName.SelectedItem == null)
                str.AppendLine("Выберите возможную стратегию");
            if (!double.TryParse(TbPayment.Text, out Payment))
                str.AppendLine("Поле выплата только число");
            else if (Payment <= 0)
                str.AppendLine("некорректная сумма выплаты");
            return str;



        }
    }
}
