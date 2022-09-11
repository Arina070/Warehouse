using SQLite;

namespace Warehouse.Data.Models
{
    [Table("sales")]
    internal class Sale
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } //TODO: replace with product id

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal ChequePrice { get; set; }

        public DateTime SellDate { get; set; } = DateTime.Now;

        public string Type { get; set; }
    }
}
