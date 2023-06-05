using SQLite;
using System.Collections.Generic;


namespace Grocery.Models
{
    public class GroceryRepository
    {
        SQLiteConnection database;
        public GroceryRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Grocery>();
        }
        public IEnumerable<Grocery> GetItems()
        {
            return database.Table<Grocery>().ToList();
        }
        public Grocery GetItem(int id)
        {
            return database.Get<Grocery>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Grocery>(id);
        }
        public int SaveItem(Grocery item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}