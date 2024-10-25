using Student_BusinessObjects;
using Student_Services;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagement_DoTheHieu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAccountServices iAccountServices;

        public MainWindow()
        {
            InitializeComponent();
            iAccountServices = new AccountServices();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Equals("") || txtPassword.Password.Equals(""))
                MessageBox.Show("Please fill all fields!");
            else
            {
                Account account = iAccountServices.GetAccount(txtEmail.Text);
                if (account == null)
                    MessageBox.Show("Can not find account!");
                else if (!(txtPassword.Password.Equals(account.Password)))
                    MessageBox.Show("Wrong password!");
                else if (account.Role != 1)
                    MessageBox.Show("You do not have permission!");
                else
                {
                    MainMenu mainMenu = new MainMenu();
                    this.Hide();
                    mainMenu.Show();
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Are you really want to Exit?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
                this.Close();
        }
    }
}