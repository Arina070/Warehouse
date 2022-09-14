using SQLite;

namespace Warehouse.Data.Models
{
    [Table("stock")]
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }  //TODO: replace with product id

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal SellPrice { get; set; }

        public DateTime BoughtDate { get; set; } = DateTime.Now;

        public string Type { get; set; }

    }
}
