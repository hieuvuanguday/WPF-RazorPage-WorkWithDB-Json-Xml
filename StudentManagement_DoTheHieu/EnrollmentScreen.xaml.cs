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
    /// Interaction logic for EnrollmentScreen.xaml
    /// </summary>
    public partial class EnrollmentScreen : Page
    {
        private readonly IEnrollmentServices _enrollmentServices;

        public EnrollmentScreen()
        {
            InitializeComponent();
            _enrollmentServices = new EnrollmentServices();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInitData();
        }

        private void LoadInitData()
        {
            this.dgvEnrollment.ItemsSource = _enrollmentServices.GetEnrollmentList();
        }

        private void dgvEnrollment_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgvEnrollment.ItemsSource = _enrollmentServices.GetEnrollmentList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                int id = int.Parse(txtSearch.Text.Trim());
                var searchResults = _enrollmentServices.SearchEnrollmentByStudentId(id);
                dgvEnrollment.ItemsSource = searchResults;
            }
            else
                LoadInitData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.StudentId = int.Parse(txtStudentID.Text.Trim());
            enrollment.CourseId = int.Parse(txtCourseID.Text.Trim());
            enrollment.EnrollmentDate = dpkEnrollmentDate.SelectedDate.Value;
            enrollment.Grade = txtGrade.Text.Trim();
            if (cbxStatus.SelectedItem is ComboBoxItem item)
                enrollment.Status = item.Content.ToString();

            if (_enrollmentServices.AddEnrollment(enrollment))
            {
                LoadInitData();
                MessageBox.Show("Add successfully!");
            }
            else
                MessageBox.Show("Add failed!");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(dgvEnrollment.SelectedItem is Enrollment selectedEnrollment)
            {
                selectedEnrollment.EnrollmentId = int.Parse(txtEnrollmentID.Text.Trim());
                selectedEnrollment.StudentId = int.Parse(txtStudentID.Text.Trim());
                selectedEnrollment.CourseId = int.Parse(txtCourseID.Text.Trim());
                selectedEnrollment.EnrollmentDate = dpkEnrollmentDate.SelectedDate.Value;
                selectedEnrollment.Grade = txtGrade.Text.Trim();
                if (cbxStatus.SelectedItem is ComboBoxItem selectedItem)
                {
                    selectedEnrollment.Status = selectedItem.Content.ToString();
                }

                if (_enrollmentServices.UpdateEnrollment(selectedEnrollment))
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
                MessageBox.Show("Please select a enrollment to update.");
            }
        }

        private void Clear()
        {
            txtEnrollmentID.Text = string.Empty;
            txtStudentID.Text = string.Empty;
            txtCourseID.Text = string.Empty;
            dpkEnrollmentDate.SelectedDate = null;
            txtGrade.Text = string.Empty;
            cbxStatus.SelectedIndex = 0;
        }

        private void dgvEnrollment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvEnrollment.SelectedItem is Enrollment selectedEnrollment)
            {
                txtEnrollmentID.Text = selectedEnrollment.EnrollmentId.ToString();
                txtStudentID.Text = selectedEnrollment.StudentId.ToString();
                txtCourseID.Text = selectedEnrollment.CourseId.ToString();
                dpkEnrollmentDate.SelectedDate = selectedEnrollment.EnrollmentDate;
                
                txtGrade.Text = selectedEnrollment.Grade;
                foreach (ComboBoxItem item in cbxStatus.Items)
                {
                    if (item.Content.ToString() == selectedEnrollment.Status)
                    {
                        cbxStatus.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dgvEnrollment.SelectedItem is Enrollment selectedEnrollment)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the enrollment '{selectedEnrollment.EnrollmentId}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) {
                    if (_enrollmentServices.DeleteEnrollment(selectedEnrollment.EnrollmentId))
                    {
                        LoadInitData();
                        MessageBox.Show("Delete successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a enrollment to delete.");
                }
            }
        }
    }
}
