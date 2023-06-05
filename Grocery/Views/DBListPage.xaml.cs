using Grocery.Models;
using Grocery.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grocery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var viewModel = new GroceryListViewModel();

            BindingContext = viewModel;
            groceryList.ItemsSource = App.DataBase.GetItems();

            var sortedList = App.DataBase.GetItems().ToList();
            groceryList.ItemsSource = sortedList;

            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Grocery selectedGrocery = (Grocery)e.SelectedItem;
            DBGroceryPage groceryPage = new DBGroceryPage();
            groceryPage.BindingContext = selectedGrocery;
            await Navigation.PushAsync(groceryPage);
        }

        private async void CreateGrocery(object sender, EventArgs e)
        {
            Grocery grocery = new Grocery();
            DBGroceryPage groceryPage = new DBGroceryPage();
            groceryPage.BindingContext = grocery;
            await Navigation.PushAsync(groceryPage);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var book = cell?.BindingContext as Grocery;

            if (book != null && book.Added)
                cell.View.BackgroundColor = Color.Green;
            else
                cell.View.BackgroundColor = Color.Red;

            cell.ForceUpdateSize();
        }
    }
}