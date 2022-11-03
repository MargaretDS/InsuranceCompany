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
    /// Логика взаимодействия для EditAgentInfoWindow.xaml
    /// </summary>
    public partial class EditAgentInfoWindow : Window
    {
        private Accounting_of_insurance_contractsEntities1 _context;
        private InsuranceAgent _agent;
        private InsurAgentsWindow _window;
        public EditAgentInfoWindow(Accounting_of_insurance_contractsEntities1 context, object o, InsurAgentsWindow agentwindow)
        {
            InitializeComponent();
            _agent = (o as Button).DataContext as InsuranceAgent;
            _window = agentwindow;
            _context = context;

            TxtFIO.Text = _agent.FIO;
            TxtPassport.Text = Convert.ToString(_agent.Passport);
        }

        private void BtnDelAgent_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(_agent.FIO, "Действительно хотите удалить сотрудника?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                _context.InsuranceAgent.Remove(_agent);
                _context.SaveChanges();

                _window.RefreshAgents();
                this.Close();
            }
        }

        private void BtnUpdateAgent_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if ((TxtFIO.Text.Equals("")) || (TxtPassport.Text.Equals("")))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }
            else if ((int.TryParse(TxtPassport.Text, out number))==false)
            {
                MessageBox.Show("Паспорт должен содержать только цифры!");
                return;
            }
            else if ((Regex.IsMatch((TxtFIO.Text), @"^[\sа-яА-Я]+$" )) == false)
            {
                MessageBox.Show("ФИО должно содержать только русские буквы!");
                return;
            }
            _agent.FIO = TxtFIO.Text;
            _agent.Passport = Convert.ToInt32(TxtPassport.Text);

            _window.RefreshAgents();
            _context.SaveChanges();
            this.Close();
        }
    }
}
