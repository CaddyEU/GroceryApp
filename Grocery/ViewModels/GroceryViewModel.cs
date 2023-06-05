using Grocery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Grocery.ViewModels
{
    public class GroceryViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        GroceryListViewModel lvm;
        public Grocery Grocery { get; private set; }
        public GroceryViewModel()
        {
            Grocery = new Grocery();
        }
        public GroceryListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string GroceryName
        {
            get { return Grocery.GroceryName; }
            set
            {
                if (Grocery.GroceryName != value)
                {
                    Grocery.GroceryName = value;
                    OnPropertyChanged("GroceryName");
                }
            }
        }
        public string Category
        {
            get { return Grocery.Category; }
            set
            {
                if (Grocery.Category != value)
                {
                    Grocery.Category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        public bool Added
        {
            get { return Grocery.Added; }
            set
            {
                if (Grocery.Added != value)
                {
                    Grocery.Added = value;
                    OnPropertyChanged("Added");
                }
            }
        }

        public string Commentary
        {
            get { return Grocery.Commentary; }
            set
            {
                if (Grocery.Commentary != value)
                {
                    Grocery.Commentary = value;
                    OnPropertyChanged("Added");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(GroceryName.Trim())) ||
                     (!string.IsNullOrEmpty(Category.Trim())) ||
                     (!string.IsNullOrEmpty(Commentary.Trim())));

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}