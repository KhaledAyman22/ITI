using MVVMDay23.Command;
using MVVMDay23.DataService;
using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMDay23.ViewModel
{
    public class Window1ViewModel : ViewModelBase
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public Student SelectedStudent { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        Student studentData;
        public Student StudentData
        {
            get { return studentData; }
            set
            {
                studentData = value;
                OnPropertyChanged();
            }
        }

        IDataService dataService;
        public Window1ViewModel(IDataService _dataService)
        {
            this.dataService = _dataService;
            StudentList = new();
            StudentData = new();
            SelectedStudent = new();
            SaveCommand = new RelayCommand(SaveData, null);
            SelectCommand = new RelayCommand(EditeStudent, null);
            DeleteCommand = new RelayCommand(DeleteStudent, null);
            ResetCommand = new RelayCommand(RestData, null);


        }

        private void SaveData(object obj)
        {
            if(StudentData !=null)
            {
            SelectedStudent.Name = studentData.Name;
            SelectedStudent.Age = studentData.Age;
            SelectedStudent.Address = studentData.Address;

             try
                {

                if(StudentData.Id<=0)
                {
                    dataService.Add(StudentData);
                    MessageBox.Show("Record Added");

                }
                else
                {

                    SelectedStudent.Id = studentData.Id;

                    dataService.Update(SelectedStudent);
                    MessageBox.Show("Record Is Updated");

                }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    Load();
                    RestData(null);

                }




            }


        }


        public void RestData( object obj)
        {
            studentData.Name = String.Empty;
            studentData.Address = String.Empty;
            studentData.Age = 0;
            studentData.Id = 0;
        }

        private void EditeStudent(object obj)
        {
            var student = (Student)obj;
            StudentData.Id=student.Id;
            StudentData.Age = student.Age;
            StudentData.Name = student.Name;
            StudentData.Address = student.Address;


        }

        private void DeleteStudent(object obj)
        {
            if (MessageBox.Show("Delete Record", "Are You Sure", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {

                    dataService.Delete((int)obj);
                    MessageBox.Show("Record Deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Load();
                }

            }
        }

        public void Load()
        {
            var students = dataService.GetAll();
            StudentList.Clear();
            foreach (var student in students)
                StudentList.Add(student);
        }


    }
}
