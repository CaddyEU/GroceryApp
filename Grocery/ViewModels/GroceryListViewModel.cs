using Grocery.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Grocery.ViewModels
{
    public class GroceryListViewModel
    {
        public ObservableCollection<GroceryViewModel> Grocery { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateGroceryCommand { protected set; get; }
        public ICommand DeleteGroceryCommand { protected set; get; }
        public ICommand SaveGroceryCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        GroceryViewModel selectedGrocery;
        public INavigation Navigation { get; set; }
        public GroceryListViewModel()
        {
            Grocery = new ObservableCollection<GroceryViewModel>();
            CreateGroceryCommand = new Command(CreateGrocery);
            DeleteGroceryCommand = new Command(DeleteGrocery);
            SaveGroceryCommand = new Command(SaveGrocery);
            BackCommand = new Command(Back);
        }
        public GroceryViewModel SelectedGrocery
        {
            get { return selectedGrocery; }
            set
            {
                if (selectedGrocery != value)
                {
                    GroceryViewModel tempGrocery = value;
                    selectedGrocery = null;
                    OnPropertyChanged("SelectedGrocery");
                    Navigation.PushAsync(new GroceryPage(tempGrocery));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateGrocery()
        {
            Navigation.PushAsync(new GroceryPage(new GroceryViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveGrocery(object groceryObject)
        {
            GroceryViewModel grocery = groceryObject as GroceryViewModel;
            if (grocery != null && grocery.IsValid && !Grocery.Contains(grocery))
            {
                Grocery.Add(grocery);
            }
            Back();
        }
        private void DeleteGrocery(object groceryObject)
        {
            GroceryViewModel grocery = groceryObject as GroceryViewModel;
            if (grocery != null)
            {
                Grocery.Remove(grocery);
            }
            Back();
        }
    }
}