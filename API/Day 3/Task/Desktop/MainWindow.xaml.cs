using API.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RequestMaker instructorRequestMaker, departmentRequestMaker, branchRequestMaker;
        public MainWindow()
        {
            InitializeComponent();
            instructorRequestMaker = new("Instructors");
            departmentRequestMaker = new("Departments");
            branchRequestMaker = new("Branches");
        }
       
        //Instructors 
        private async void GetInstructorsBtn(object sender, RoutedEventArgs e)
        {
            var res = await instructorRequestMaker.MakeRequest(null, null, HttpMethod.Get, "");

            string contetnt = await res.Content.ReadAsStringAsync();
            responseIns.Clear();
            responseIns.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
        }

        private async void GetInstructorBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idIns.Text, out int ID))
            {
                var res = await instructorRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseIns.Clear();
                responseIns.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }

        private async void PutInstructorBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var instructor = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(bodyIns.Text), typeof(InstructorDTO));
                var res = await instructorRequestMaker.MakeRequest(instructor, typeof(InstructorDTO), HttpMethod.Put, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseIns.Clear();
                responseIns.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            catch(Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        
        private async void PostInstructorBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var instructor = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(bodyIns.Text), typeof(InstructorDTO));
                var res = await instructorRequestMaker.MakeRequest(instructor, typeof(InstructorDTO), HttpMethod.Post, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseIns.Clear();
                responseIns.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        
        private async void DeleteInstructorBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idIns.Text, out int ID))
            {
                var res = await instructorRequestMaker.MakeRequest(null, null, HttpMethod.Delete, $"{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseIns.Clear();
                responseIns.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }
       
        //Branches
        private async void GetBranchesBtn(object sender, RoutedEventArgs e)
        {
            var res = await branchRequestMaker.MakeRequest(null, null, HttpMethod.Get, "");

            string contetnt = await res.Content.ReadAsStringAsync();
            responseBrnch.Clear();
            responseBrnch.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
        }
       
        private async void GetBranchBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idBrnch.Text, out int ID))
            {
                var res = await branchRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseBrnch.Clear();
                responseBrnch.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }
        
        private async void PutBranchBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var branch = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(bodyBrnch.Text), typeof(BranchDTO));
                var res = await branchRequestMaker.MakeRequest(branch, typeof(BranchDTO), HttpMethod.Put, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseBrnch.Clear();
                responseBrnch.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        private async void PostBranchBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var branch = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(bodyBrnch.Text), typeof(BranchDTO));
                var res = await branchRequestMaker.MakeRequest(branch, typeof(BranchDTO), HttpMethod.Post, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseBrnch.Clear();
                responseBrnch.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        private async void DeleteBranchBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idBrnch.Text, out int ID))
            {
                var res = await branchRequestMaker.MakeRequest(null, null, HttpMethod.Delete, $"{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseBrnch.Clear();
                responseBrnch.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }
        
        //Departments
        private async void GetDepartmentsBtn(object sender, RoutedEventArgs e)
        {
            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, "");

            string contetnt = await res.Content.ReadAsStringAsync();
            responseDep.Clear();
            responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
        }

        private async void GetDepartmentsDetailedBtn(object sender, RoutedEventArgs e)
        {
            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, "Detailed");

            string contetnt = await res.Content.ReadAsStringAsync();
            responseDep.Clear();
            responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
        }
        
        private async void GetDepartmentBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idDep.Text, out int ID))
            {
                var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseDep.Clear();
                responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }
      
        private async void GetDepartmentDetailedBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idDep.Text, out int ID))
            {
                var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"Detailed/{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseDep.Clear();
                responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }
        
        private async void PutDepartmentBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var department = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(bodyDep.Text), typeof(DepartmentDTO));
                var res = await departmentRequestMaker.MakeRequest(department, typeof(DepartmentDTO), HttpMethod.Put, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseDep.Clear();
                responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        
        private async void PostDepartmentBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var department = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(bodyDep.Text), typeof(DepartmentDTO));
                var res = await departmentRequestMaker.MakeRequest(department, typeof(DepartmentDTO), HttpMethod.Post, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseDep.Clear();
                responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        
        private async void DeleteDepartmentBtn(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idDep.Text, out int ID))
            {
                var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Delete, $"{ID}");

                string contetnt = await res.Content.ReadAsStringAsync();
                responseDep.Clear();
                responseDep.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented);
            }
            else
            {
                MessageBox.Show("Id must be a number");
            }
        }
    }
}
