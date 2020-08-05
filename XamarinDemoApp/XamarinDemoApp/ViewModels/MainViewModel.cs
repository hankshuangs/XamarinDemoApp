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
        private List<Employee> _searchedEmployees;
        private string _keyword;
        private bool _isBusy = false;
        private string _statusMessage;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged();
            }
        }

        public List<Employee> EmployeesList
        {
            get => _employeesList;
            set
            {
                _employeesList = value;
                OnPropertyChanged();
            }
        }

        public List<Employee> SearchedEmployees
        {
            get
            {
                return _searchedEmployees;
            }
            set
            {
                _searchedEmployees = value;
                OnPropertyChanged();
            }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command(async () => await InitializeDataAsync());
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var employeesServices = new EmployeeServices();
                    var isSuccess = await employeesServices.PostEmployeeAsync(_selectedEmployee);
                    if (isSuccess)
                    {
                        StatusMessage = "新增成功";
                    }
                    else
                    {
                        StatusMessage = "新增失敗";
                    }
                    IsBusy = false;
                });
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var employeesServices = new EmployeeServices();
                    var isSuccess = await employeesServices.PutEmployeeAsync(_selectedEmployee.Id, _selectedEmployee);
                    if (isSuccess)
                    {
                        StatusMessage = "更新成功";
                    }
                    else
                    {
                        StatusMessage = "更新失敗";
                    }
                    IsBusy = false;
                });
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var employeesServices = new EmployeeServices();
                    var isSuccess = await employeesServices.DeleteEmployeeAsync(_selectedEmployee.Id);
                    if (isSuccess)
                    {
                        StatusMessage = "刪除成功";
                    }
                    else
                    {
                        StatusMessage = "刪除失敗";
                    }
                    IsBusy = false;
                });
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var employeesServices = new EmployeeServices();
                    SearchedEmployees = await employeesServices.GetEmployeesByKeywordAsync(_keyword);
                    IsBusy = false;
                });
            }
        }


        public MainViewModel()
        {
            InitializeDataAsync();
        }
        private async Task InitializeDataAsync()
        {
            IsBusy = true;
            var employeeServices = new EmployeeServices();
            EmployeesList = await employeeServices.GetEmployeesAsync();
            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
