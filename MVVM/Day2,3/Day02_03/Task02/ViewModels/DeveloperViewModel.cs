using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Task02.DAL.Models;
using Task02.BLL.Managers;
using Task02.Commands;
using Task02.BLL.UIModels;
using Task02.BLL;

namespace Task02.ViewModels
{
    public class DeveloperViewModel:UIModelBase
    {
        public ObservableCollection<Developer_UI> DeveloperList { get; set; }
        public Developer_UI SelectedDeveloper { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        private readonly IDeveloperManager _developerManager;

        public Developer_UI DeveloperData { get; set; }

        public DeveloperViewModel(IDeveloperManager developerManager)
        {
            DeveloperList = new();
            DeveloperData = new();
            SelectedDeveloper = new();
            SaveCommand = new RelayCommand(SaveData, null);
            SelectCommand = new RelayCommand(EditDeveloper, null);
            DeleteCommand = new RelayCommand(DeleteDeveloper, null);
            ResetCommand = new RelayCommand(ResetDeveloper, null);
            _developerManager = developerManager;
        }

        private void SaveData(object obj)
        {
            if (DeveloperData is not null)
            {
                UpdateSelectedDeveloper();

                try
                {

                    if (DeveloperData.Id <= 0)
                    {
                        _developerManager.Add(DeveloperData);
                        MessageBox.Show("Record Added");

                    }
                    else
                    {
                        _developerManager.Update(SelectedDeveloper);
                        MessageBox.Show("Record Is Updated");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DeveloperData = new();
                    SelectedDeveloper = DeveloperData;
                    Load();
                    ResetDeveloper(null);
                }
            }


        }

        private void UpdateSelectedDeveloper()
        {
            SelectedDeveloper.Name = DeveloperData.Name;
        }

        public void ResetDeveloper(object? obj)
        {
            DeveloperData.Name = string.Empty;
            DeveloperData.Id = 0;
        }

        private void EditDeveloper(object obj)
        {
            var developer = (Developer_UI)obj;
            SelectedDeveloper.Id = developer.Id;
            DeveloperData.Id = developer.Id;
            DeveloperData.Name = developer.Name;
        }

        private void DeleteDeveloper(object obj)
        {
            if (MessageBox.Show("Record Deletion", "Are You Sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    _developerManager.Delete((int)obj);
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
            var developers = _developerManager.GetAll();
            DeveloperList.Clear();

            if (developers is null) return;

            foreach (var developer in developers)
                DeveloperList.Add(developer);
        }
    }
}
