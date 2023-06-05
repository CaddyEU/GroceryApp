using Grocery.Services;
using Grocery.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grocery
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "grocery.db";
        public static GroceryRepository database;
        public static GroceryRepository DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new GroceryRepository
                        (Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
        }
    }
}
