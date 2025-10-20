using System.Windows;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.View;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuRoles_Click(object sender, RoutedEventArgs e)
        {
            WindowRole windowRole = new WindowRole();
            windowRole.Owner = this;
            windowRole.ShowDialog();
        }

        private void MenuEmployees_Click(object sender, RoutedEventArgs e)
        {
            WindowEmployee windowEmployee = new WindowEmployee();
            windowEmployee.Owner = this;
            windowEmployee.ShowDialog();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}