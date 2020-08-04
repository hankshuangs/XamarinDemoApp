using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDemoApp.Models;
using XamarinDemoApp.Services;

namespace XamarinDemoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employee> _employeesList;
        private Employee _selectedEmployee = new Employee();

        public List<Employee> EmployeesList
        {
            get => _employeesList;
            set
            {
                _employeesList = value;
                OnPropertyChanged();
            }
        }

        public Employee SelectedEmployee 
        { 
            get => _selectedEmployee;
            set { 
                _selectedEmployee = value;
                OnPropertyChanged();
            } 
        }

        public Command PostCommand
        {
            get 
            {
                return new Command(async() =>
                {
                    var employeesServices = new EmployeeServices();
                    await employeesServices.PostEmployeeAsync(_selectedEmployee);
                });
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var employeesServices = new EmployeeServices();
                    await employeesServices.PutEmployeeAsync(_selectedEmployee.Id,_selectedEmployee);
                });
            }
        }

        public MainViewModel()
        {
            InitializeDateAsync();
        }
        private async void InitializeDateAsync()
        {
            var employeeServices = new EmployeeServices();

            EmployeesList = await employeeServices.GetEmployeesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
