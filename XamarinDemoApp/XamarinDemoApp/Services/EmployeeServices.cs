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

        public async Task<bool> PostEmployeeAsync(Employee employee)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            var IsSuccessStatusCode = await restClient.PostAsync(employee);
            return IsSuccessStatusCode;
        }

        public async Task<bool> PutEmployeeAsync(int id ,Employee employee)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            var IsSuccessStatusCode = await restClient.PutAsync(id,employee);
            return IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            var IsSuccessStatusCode = await restClient.DeleteAsync(id);
            return IsSuccessStatusCode;
        }

        public async Task<List<Employee>> GetEmployeesByKeywordAsync(string keyword)
        {
            RestClient<Employee> restClient = new RestClient<Employee>();
            var employeesList = await restClient.GetByKeywordAsAsync(keyword);
            return employeesList;
        }
    }
}
