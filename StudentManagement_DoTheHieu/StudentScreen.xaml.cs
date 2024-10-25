using Student_BusinessObjects;
using Student_Services;
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

namespace StudentManagement_DoTheHieu
{
    /// <summary>
    /// Interaction logic for StudentScreen.xaml
    /// </summary>
    public partial class StudentScreen : Page
    {
        private readonly IStudentServices _studentServices;

        public StudentScreen()
        {
            InitializeComponent();
            _studentServices = new StudentServices();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInitData();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                var searchResults = _studentServices.SearchStudentByName(name);
                dgvStudenProfile.ItemsSource = searchResults;
            }
            else
                LoadInitData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.FullName = txtFullName.Text;
            student.DateOfBirth = DateOnly.FromDateTime(dpkBirthday.SelectedDate.Value);
            student.Gender = rbMale.IsChecked == true ? rbMale.Content.ToString() : rbFemale.Content.ToString();
            student.PhoneNumber = txtPhoneNumber.Text;
            student.Email = txtEmail.Text;
            student.Address = txtAddress.Text;
            if(cbxStatus.SelectedItem is ComboBoxItem item)
                student.Status = item.Content.ToString();

            if (_studentServices.AddStudent(student))
            {
                LoadInitData();
                MessageBox.Show("Add successfully!");
            }
            else
                MessageBox.Show("Add failed!");
        }

        private void dgvStudentProfile_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgvStudenProfile.ItemsSource = _studentServices.GetStudentList();
        }

        private void LoadInitData()
        {
            this.dgvStudenProfile.ItemsSource = _studentServices.GetStudentList();
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgvStudenProfile.SelectedItem is Student selectedStudent)
            {
                selectedStudent.FullName = txtFullName.Text;
                selectedStudent.DateOfBirth = DateOnly.FromDateTime(dpkBirthday.SelectedDate.Value);
                selectedStudent.PhoneNumber = txtPhoneNumber.Text;
                selectedStudent.Email = txtEmail.Text;
                selectedStudent.Address = txtAddress.Text;
                selectedStudent.Gender = rbMale.IsChecked == true ? rbMale.Content.ToString() : rbFemale.Content.ToString();

                if (cbxStatus.SelectedItem is ComboBoxItem selectedItem)
                {
                    selectedStudent.Status = selectedItem.Content.ToString();
                }
                if (_studentServices.UpdateStudent(selectedStudent))
                {
                    LoadInitData();
                    MessageBox.Show("Update successfully!");
                }
                else
                {
                    MessageBox.Show("Update failed!");
                }
                Clear();
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void Clear()
        {
            txtStudentID.Text = string.Empty;
            txtFullName.Text = string.Empty;
            dpkBirthday.SelectedDate =null;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            rbMale.IsChecked = true;
            cbxStatus.SelectedIndex = 0;
        }

        private void dgvStudenProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvStudenProfile.SelectedItem is Student selectedStudent)
            {
                txtStudentID.Text = selectedStudent.StudentId.ToString();
                txtFullName.Text = selectedStudent.FullName;
                dpkBirthday.SelectedDate = selectedStudent.DateOfBirth.ToDateTime(TimeOnly.MinValue);
                txtPhoneNumber.Text = selectedStudent.PhoneNumber;
                txtEmail.Text = selectedStudent.Email;
                txtAddress.Text = selectedStudent.Address;

                if (selectedStudent.Gender == rbMale.Content.ToString())
                    rbMale.IsChecked = true;
                else
                    rbFemale.IsChecked = true;

                foreach (ComboBoxItem item in cbxStatus.Items)
                {
                    if (item.Content.ToString() == selectedStudent.Status)
                    {
                        cbxStatus.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvStudenProfile.SelectedItem is Student selectedStudent)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the student '{selectedStudent.FullName}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (_studentServices.DeleteStudent(selectedStudent.StudentId))
                    {
                        LoadInitData();
                        MessageBox.Show("Delete successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }
}
