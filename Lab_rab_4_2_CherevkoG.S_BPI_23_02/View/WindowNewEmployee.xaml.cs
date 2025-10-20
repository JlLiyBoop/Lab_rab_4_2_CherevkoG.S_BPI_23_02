using System.Windows;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.View
{
    public partial class WindowNewEmployee : Window
    {
        public WindowNewEmployee()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}