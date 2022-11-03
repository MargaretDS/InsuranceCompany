using System;
using System.Data;
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

namespace InsuranceCompany.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        public static Accounting_of_insurance_contractsEntities1 _context = new Accounting_of_insurance_contractsEntities1();
        public WorkersWindow()
        {
            InitializeComponent();
            RefreshWorkers();
        }
        public void RefreshWorkers()
        {
            DataGridWorkers.ItemsSource = _context.Worker.OrderBy(h => h.FIO).ToList();
        }

        private void ReturnMain_Click(object sender, RoutedEventArgs e)

        {
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void BtnEditWorkersInfo_Click(object sender, RoutedEventArgs e)
        {
            EditWorkersWindow editWorkersWindow = new EditWorkersWindow(_context,sender,this);
            editWorkersWindow.ShowDialog();
        }

        private void BtnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow(_context, this);
            addWorkerWindow.ShowDialog();
        }
    
    }
}
