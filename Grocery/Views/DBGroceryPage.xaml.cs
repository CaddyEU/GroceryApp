using Grocery.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grocery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBGroceryPage : ContentPage
    {
        public DBGroceryPage()
        {
            InitializeComponent();
        }
        private void SaveGrocery(object sender, EventArgs e)
        {
            var grocery = (Grocery)BindingContext;
            if (!String.IsNullOrEmpty(grocery.GroceryName))
            {
                App.DataBase.SaveItem(grocery);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteGrocery(object sender, EventArgs e)
        {
            var grocery = (Grocery)BindingContext;
            App.DataBase.DeleteItem(grocery.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}