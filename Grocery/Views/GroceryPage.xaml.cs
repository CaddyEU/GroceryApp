using Grocery.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grocery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroceryPage : ContentPage
    {
        public GroceryViewModel ViewModel { get; private set; }
        public GroceryPage(GroceryViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}