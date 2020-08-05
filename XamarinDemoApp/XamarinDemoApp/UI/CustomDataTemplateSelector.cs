using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinDemoApp.Models;

namespace XamarinDemoApp.UI
{
    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _financeTemplate = new DataTemplate(typeof(FinanceTemplate));
        private readonly DataTemplate _hrTemplate = new DataTemplate(typeof(HrTemplate));
        protected override DataTemplate OnSelectTemplate(object item ,BindableObject container)
        {
            var employee = item as Employee;
            if (employee.Department=="Finance")
            {
                return _financeTemplate;
            }
            return _hrTemplate;
        }
    }
}
