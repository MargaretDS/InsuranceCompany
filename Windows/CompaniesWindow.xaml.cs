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
using InsuranceCompany.Models;
using Word = Microsoft.Office.Interop.Word;

namespace InsuranceCompany.Windows
{
    /// <summary>
    /// Логика взаимодействия для CompaniesWindow.xaml
    /// </summary>
    public partial class CompaniesWindow : Window
    {
        public static Accounting_of_insurance_contractsEntities1 _context = new Accounting_of_insurance_contractsEntities1();

        public CompaniesWindow()
        {
            InitializeComponent();
            RefreshCompanies();
        }
        public void RefreshCompanies()
        {
            DataGridCompanies.ItemsSource = _context.Company.OrderBy(h => h.FullName).ToList();
        }

        private void ReturnMain_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }


    }
}
