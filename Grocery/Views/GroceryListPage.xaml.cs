using Grocery.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grocery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroceryListPage : ContentPage
    {
        public GroceryListPage()
        {
            InitializeComponent();
            BindingContext = new GroceryListViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}