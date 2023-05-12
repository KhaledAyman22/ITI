using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Task01.DAL.Models;
using Task01.BLL.Managers;
using Task01.Commands;
using Task01.BLL.UIModels;
using Task01.BLL;

namespace Task01.ViewModels
{
    public class StudentViewModel:UIModelBase
    {
        public ObservableCollection<Student_UI> StudentList { get; set; }
        public Student_UI SelectedStudent { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        private readonly IStudentManager _studentManager;

        public Student_UI StudentData { get; set; }

        public StudentViewModel(IStudentManager studentManager)
        {
            StudentList = new();
            StudentData = new();
            SelectedStudent = new();
            SaveCommand = new RelayCommand(SaveData, null);
            SelectCommand = new RelayCommand(EditStudent, null);
            DeleteCommand = new RelayCommand(DeleteStudent, null);
            ResetCommand = new RelayCommand(ResetStudent, null);
            _studentManager = studentManager;
        }

        private void SaveData(object obj)
        {
            if (StudentData is not null)
            {
                UpdateSelectedStudent();

                try
                {

                    if (StudentData.Id <= 0)
                    {
                        _studentManager.Add(StudentData);
                        MessageBox.Show("Record Added");

                    }
                    else
                    {
                        _studentManager.Update(SelectedStudent);
                        MessageBox.Show("Record Is Updated");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    StudentData = new();
                    SelectedStudent = StudentData;
                    Load();
                    ResetStudent(null);
                }
            }


        }

        private void UpdateSelectedStudent()
        {
            SelectedStudent.Name = StudentData.Name;
            SelectedStudent.Age = StudentData.Age;
            SelectedStudent.Address = StudentData.Address;
        }

        public void ResetStudent(object? obj)
        {
            StudentData.Name = string.Empty;
            StudentData.Address = string.Empty;
            StudentData.Age = 0;
            StudentData.Id = 0;
        }

        private void EditStudent(object obj)
        {
            var student = (Student_UI)obj;
            SelectedStudent.Id = student.Id;
            StudentData.Id = student.Id;
            StudentData.Age = student.Age;
            StudentData.Name = student.Name;
            StudentData.Address = student.Address;
        }

        private void DeleteStudent(object obj)
        {
            if (MessageBox.Show("Record Deletion", "Are You Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    _studentManager.Delete((int)obj);
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
            var students = _studentManager.GetAll();
            StudentList.Clear();

            if (students is null) return;

            foreach (var student in students)
                StudentList.Add(student);
        }
    }
}
