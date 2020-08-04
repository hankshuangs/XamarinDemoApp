using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDemoApp.Models;
using XamarinDemoApp.ViewModels;
using XamarinDemoApp.Views;

namespace XamarinDemoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        private async void BtnNew_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewEmployeePage());
        }

        private async void ListView_OnItemTapped(object sender,ItemTappedEventArgs e)
        {
            var employee = EmployeeListView.SelectedItem as Employee;
            if (employee !=null)
            {
                var mainViewModel = BindingContext as MainViewModel;
                if (mainViewModel != null)
                {
                    mainViewModel.SelectedEmployee = employee;
                    await Navigation.PushAsync(new NewEmployeePage(mainViewModel));
                }
            }
        }
    }


}
