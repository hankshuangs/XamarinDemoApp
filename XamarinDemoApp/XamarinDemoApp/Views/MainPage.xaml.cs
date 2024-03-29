﻿using System;
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

        private async void BtnSearch_OnClicked(object sender, EventArgs e)
        {
            MainViewModel mainViewModel = BindingContext as MainViewModel;
            if(mainViewModel != null)
            {
                await Navigation.PushAsync(new SearchPage(mainViewModel));
            }
        }

        private async void ListView_OnItemTapped(object sender,ItemTappedEventArgs e)
        {
            Employee employee = EmployeesListView.SelectedItem as Employee;
            if (employee !=null)
            {
                MainViewModel mainViewModel = BindingContext as MainViewModel;
                if (mainViewModel != null)
                {
                    mainViewModel.SelectedEmployee = employee;
                    await Navigation.PushAsync(new NewEmployeePage(mainViewModel));
                }
            }
        }
    }


}
