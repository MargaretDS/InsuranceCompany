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
using InsuranceCompany.Windows;

namespace InsuranceCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            WorkersWindow window = new WorkersWindow();
            window.ShowDialog();
        }

        private void Companies_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CompaniesWindow window = new CompaniesWindow();
            window.ShowDialog();
        }

        private void InsuranceAgents_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            InsurAgentsWindow window = new InsurAgentsWindow();
            window.ShowDialog();
        }

        private void Contracts_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            ContractsWindow window = new ContractsWindow();
            window.ShowDialog();
        }
    }
}
