using System.Windows;
using System.Windows.Controls;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.View;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ThemesController.SetTheme(ThemesController.ThemeType.Light);
        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((MenuItem)sender).Uid))
            {
                case 0:
                    ThemesController.SetTheme(ThemesController.ThemeType.Light);
                    break;
                case 1:
                    ThemesController.SetTheme(ThemesController.ThemeType.Dark);
                    break;
            }

            e.Handled = true;
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