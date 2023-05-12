using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Task01.Command;
using Task01.Model;

namespace Task01.ViewModel
{
    public class CarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Car _car;

        public Car NewCar
        {
            get => _car;
            set
            {
                _car = value;
                OnPropertyChanged(nameof(NewCar));
            }
        }
        
        public ObservableCollection<Car> CarsList { get; set; }
        
        public ICommand AddCommand { get; set; }

        public CarViewModel()
        {
            AddCommand = new AddCarCommand(Add, CanAdd);

            _car = new();

            CarsList = new()
            {
                new() { Id = 1, Make = "Toyota", Model = "Corolla", Price = 15000.00m },
                new() { Id = 2, Make = "Honda", Model = "Civic", Price = 16000.00m },
                new() { Id = 3, Make = "Ford", Model = "Mustang", Price = 25000.00m }
            };
        }

        private bool CanAdd(object obj)
        {
            return true;
        }

        private void Add(object obj)
        {
            if (obj is Car car)
            {
                CarsList.Add(car);
                MessageBox.Show("Added");
                NewCar = new();
            }
        }
    }
}
