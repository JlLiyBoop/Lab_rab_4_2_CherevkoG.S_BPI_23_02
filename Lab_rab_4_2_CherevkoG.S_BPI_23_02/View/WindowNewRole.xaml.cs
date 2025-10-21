using System.Windows;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.Helper;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.View
{
    public partial class WindowNewRole : Window
    {
        public WindowNewRole()
        {
            InitializeComponent();
            DataContext = new DialogViewModel(this);
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }


    public class DialogViewModel
    {
        private Window dialogWindow;

        public DialogViewModel(Window window)
        {
            dialogWindow = window;
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                (saveCommand = new RelayCommand(obj =>
                {
                    dialogWindow.DialogResult = true;
                }));
            }
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                (cancelCommand = new RelayCommand(obj =>
                {
                    dialogWindow.DialogResult = false;
                }));
            }
        }
    }
}