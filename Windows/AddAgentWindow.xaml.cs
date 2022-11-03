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
using InsuranceCompany.Windows;

namespace InsuranceCompany.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAgentWindow.xaml
    /// </summary>
    public partial class AddAgentWindow : Window
    {
        private Accounting_of_insurance_contractsEntities1 _context;
        private InsurAgentsWindow _window;
        public AddAgentWindow(Accounting_of_insurance_contractsEntities1 context,  InsurAgentsWindow agentwindow)
        { 
                InitializeComponent();
            this._context = context;
            this._window = agentwindow;
        }

        private void BtnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if ((TxtFIO.Text.Equals("")) || (TxtPassport.Text.Equals("")))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }
            else if ((int.TryParse(TxtPassport.Text, out number)) == false)
            {
                MessageBox.Show("Паспорт должен содержать только цифры!");
                return;
            }
            else if ((Regex.IsMatch((TxtFIO.Text), @"^[\sа-яА-Я]+$")) == false)
            {
                MessageBox.Show("ФИО должно содержать только русские буквы!");
                return;
            }
            _context.InsuranceAgent.Add(new InsuranceAgent()
            {
                FIO = TxtFIO.Text,
                Passport = Convert.ToInt32(TxtPassport.Text),
            });


            _context.SaveChanges();
            _window.RefreshAgents();

            this.Close();
        }
    }
}
    

