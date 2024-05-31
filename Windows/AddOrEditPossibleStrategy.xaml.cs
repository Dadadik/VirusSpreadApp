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
    /// Логика взаимодействия для AddOrEditPossibleStrategy.xaml
    /// </summary>
    public partial class AddOrEditPossibleStrategy : Window
    {
        private PossibleStrategy _currentPossibleStrategy = new PossibleStrategy();
        public AddOrEditPossibleStrategy(PossibleStrategy possibleStrategy)
        {
            InitializeComponent();
            if(possibleStrategy != null)
                _currentPossibleStrategy = possibleStrategy;
            DataContext = _currentPossibleStrategy;
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
                if (_currentPossibleStrategy.Id == 0)
                    VirusSpreadEntities.GetContext().PossibleStrategies.Add(_currentPossibleStrategy);
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
            if (string.IsNullOrWhiteSpace(_currentPossibleStrategy.Name))
                str.AppendLine("Поле название введено некорректно");          
            if (string.IsNullOrWhiteSpace(_currentPossibleStrategy.Description))
                str.AppendLine("Поле описание введено некорректно");
            return str;
        }
    }
}
