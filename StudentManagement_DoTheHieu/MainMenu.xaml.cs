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
using System.Windows.Shapes;

namespace StudentManagement_DoTheHieu
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new StudentScreen();
        }

        private void btnCourse_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new CourseScreen();
        }

        private void btnEnrollment_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new EnrollmentScreen();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Are you really want to Exit?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
