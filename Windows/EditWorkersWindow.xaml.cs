using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditWorkersWindow.xaml
    /// </summary>
    public partial class EditWorkersWindow : Window
    {
        private Accounting_of_insurance_contractsEntities1 _context;
        private Worker _worker;
        private WorkersWindow _window;
        public EditWorkersWindow(Accounting_of_insurance_contractsEntities1 context, object o, WorkersWindow workerwindow)
        {
            InitializeComponent();
            _worker = (o as Button).DataContext as Worker;
            _window = workerwindow;
            _context = context;

            CmbCategory.ItemsSource = _context.RiskCategory.ToList();
            TxtFIO.Text = _worker.FIO;
            TxtAge.Text = Convert.ToString(_worker.Age);
            
        }

        private void BtnDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(_worker.FIO, "Действительно хотите удалить сотрудника?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                _context.Worker.Remove(_worker);
                _context.SaveChanges();

                _window.RefreshWorkers();
                this.Close();
            }
        }

        private void BtnUpdateWorkerInfo_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if ((TxtFIO.Text.Equals("")) || (TxtAge.Text.Equals("")) || (CmbCategory.SelectedIndex == -1))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }
            else if ((int.TryParse(TxtAge.Text, out number)) == false)
            {
                MessageBox.Show("Возраст должен содержать только цифры!");
                return;
            }
            else if (((Convert.ToInt32(TxtAge.Text)) <= 18) || ((Convert.ToInt32(TxtAge.Text)) >= 102)) 
            {
                MessageBox.Show("Возраст должен находиться в диапозоне от 18 до 102!");
                return;
            }
            else if ((Regex.IsMatch((TxtFIO.Text), @"^[\sа-яА-Я]+$")) == false)
            {
                MessageBox.Show("ФИО должно содержать только русские буквы!");
                return;
            }
            _worker.FIO = TxtFIO.Text;
            _worker.Age = Convert.ToInt32(TxtAge.Text);
            _worker.RiskCategory = CmbCategory.SelectedItem as RiskCategory;

            _window.RefreshWorkers();
            _context.SaveChanges();
            this.Close();
        
    }
    }
}
