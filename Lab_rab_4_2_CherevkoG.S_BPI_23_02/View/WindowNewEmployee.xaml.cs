using System.Windows;
using System.Windows.Controls;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.Model;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.ViewModel;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.View
{
    public partial class WindowNewEmployee : Window
    {
        public ComboBox CbRole => cbRole;

        public WindowNewEmployee()
        {
            InitializeComponent();
            Loaded += WindowNewEmployee_Loaded;
        }

        private void WindowNewEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            var roleViewModel = new RoleViewModel();
            cbRole.ItemsSource = roleViewModel.ListRole;

            var person = DataContext as PersonDpo;
            if (person != null && !string.IsNullOrEmpty(person.RoleName))
            {
                foreach (Role role in cbRole.Items)
                {
                    if (role.NameRole == person.RoleName)
                    {
                        cbRole.SelectedItem = role;
                        break;
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}