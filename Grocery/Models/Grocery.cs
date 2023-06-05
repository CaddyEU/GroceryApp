using SQLite;

namespace Grocery.Models
{
    [Table("Grocery")]
    public class Grocery
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string GroceryName { get; set; }
        public string Category { get; set; }
        public bool Added { get; set; }
        public string Commentary { get; set; }
    }
}