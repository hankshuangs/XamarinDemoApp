using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinDemoApp.Models;
using XamarinDemoApp.RestClient;

namespace XamarinDemoApp.Services
{
    public class EmployeeServices
    {

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            var employeesList = await restClient.GetAsync();
            return employeesList;
        }

        public async Task PostEmployeeAsync(Employee employee)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            await restClient.PostAsync(employee);
        }
        public async Task PutEmployeeAsync(int id ,Employee employee)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            await restClient.PutAsync(id,employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            await restClient.DeleteAsync(id);
        }

        public async Task<List<Employee>> GetEmployeesByKeywordAsync()
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            var employeesList = await restClient.GetAsync();
            return employeesList;
        }
    }
}
