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
            DataContext = new EmployeeDialogViewModel(this);
            Loaded += WindowNewEmployee_Loaded;
        }

        private void WindowNewEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as EmployeeDialogViewModel;
            viewModel?.LoadRoles();

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
    }

    public class EmployeeDialogViewModel : DialogViewModel
    {
        private WindowNewEmployee dialogWindow;

        public EmployeeDialogViewModel(WindowNewEmployee window) : base(window)
        {
            dialogWindow = window;
        }

        public void LoadRoles()
        {
            var roleViewModel = new RoleViewModel();
            dialogWindow.CbRole.ItemsSource = roleViewModel.ListRole;
        }
    }
}