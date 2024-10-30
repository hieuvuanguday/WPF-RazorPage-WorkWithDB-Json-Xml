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
    /// Interaction logic for CourseScreen.xaml
    /// </summary>
    public partial class CourseScreen : Page
    {
        private readonly ICourseServices _courseServices;

        public CourseScreen()
        {
            InitializeComponent();
            _courseServices = new CourseServices();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInitData();
        }

        private void LoadInitData()
        {
            this.dgvCourse.ItemsSource = _courseServices.GetCourseList();
        }
        private void dgvCourse_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgvCourse.ItemsSource = _courseServices.GetCourseList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                var searchResults = _courseServices.SearchCourseByName(name);
                dgvCourse.ItemsSource = searchResults;
            }
            else
                LoadInitData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            course.CourseName = txtCourseName.Text;
            course.Credits = int.Parse(txtCredit.Text);

            course.StartDate = dpkStartDate.SelectedDate.Value;
            course.EndDate = dpkEndDate.SelectedDate.Value;
            
            if (_courseServices.AddCourse(course))
            {
                LoadInitData();
                MessageBox.Show("Add successfully!");
            }
            else
                MessageBox.Show("Add failed!");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgvCourse.SelectedItem is Course selectedCourse)
            {
                selectedCourse.CourseName = txtCourseName.Text;
                selectedCourse.Credits = int.Parse(txtCredit.Text);
                selectedCourse.StartDate = dpkStartDate.SelectedDate.Value;
                selectedCourse.EndDate = dpkEndDate.SelectedDate.Value;

                if (_courseServices.UpdateCourse(selectedCourse))
                {
                    LoadInitData();
                    MessageBox.Show("Update successfully!");
                }
                else
                {
                    MessageBox.Show("Update failed!");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to update.");
            }
        }

        private void Clear()
        {
            txtCourseID.Text = string.Empty;
            txtCourseName.Text = string.Empty;
            txtCredit.Text = string.Empty;
            dpkStartDate.SelectedDate = null;
            dpkEndDate.SelectedDate = null;
        }

        private void dgvCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgvCourse.SelectedItem is Course selectedCourse)
            {
                txtCourseID.Text = selectedCourse.CourseId.ToString();
                txtCourseName.Text = selectedCourse.CourseName.ToString();
                txtCredit.Text = selectedCourse.Credits.ToString();
                dpkStartDate.SelectedDate = selectedCourse.StartDate;
                dpkEndDate.SelectedDate = selectedCourse.EndDate;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvCourse.SelectedItem is Course selectedCourse) 
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the course '{selectedCourse.CourseName}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) 
                {
                    if (_courseServices.DeleteCourse(selectedCourse.CourseId)) 
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
                    MessageBox.Show("Please select a course to delete.");
                }
            }
        }
    }
}
