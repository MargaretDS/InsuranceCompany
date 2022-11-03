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
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {

        private Accounting_of_insurance_contractsEntities1 _context;
        private WorkersWindow _window;
        public AddWorkerWindow(Accounting_of_insurance_contractsEntities1 accounting_Of_Insurance_ContractsEntities, WorkersWindow workersWindow)
        {
            InitializeComponent();
            this._context = accounting_Of_Insurance_ContractsEntities;
            this._window = workersWindow;

            CmbCategory.ItemsSource = _context.RiskCategory.ToList();
        }

        private void BtnAddWorker_Click(object sender, RoutedEventArgs e)
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
            _context.Worker.Add(new Worker()
            {
                FIO = TxtFIO.Text,
                Age = Convert.ToInt32(TxtAge.Text),
                RiskCategory = CmbCategory.SelectedItem as RiskCategory
            });

            _context.SaveChanges();
            _window.RefreshWorkers();

            this.Close(); }
        }
    }

