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

namespace InsuranceCompany.Windows
{
    /// <summary>
    /// Логика взаимодействия для InsurAgentsWindow.xaml
    /// </summary>
    public partial class InsurAgentsWindow : Window
    {
        public static Accounting_of_insurance_contractsEntities1 _context= new Accounting_of_insurance_contractsEntities1();
        public InsurAgentsWindow()
        {
            InitializeComponent();
            RefreshAgents();
        }

        public void RefreshAgents()
        {
            DataGridInAgents.ItemsSource = _context.InsuranceAgent.ToList();
        }

        

        private void ReturnMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void BtnEditAgentInfo_Click(object sender, RoutedEventArgs e)
        {
            EditAgentInfoWindow editAgentWindow = new EditAgentInfoWindow(_context, sender, this);
            editAgentWindow.ShowDialog();
        }

        private void BtnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            AddAgentWindow addAgentWindow = new AddAgentWindow(_context, this);
            addAgentWindow.ShowDialog();
        }
    }
}
