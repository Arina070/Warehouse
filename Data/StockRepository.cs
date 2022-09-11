using SQLite;
using Warehouse.Data.Models;

namespace Warehouse.Data
{
    public class StockRepository
    {
        private readonly string _dbPath;

        public StockRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private SQLiteAsyncConnection connection;

        private async Task<SQLiteAsyncConnection> GetConnection()
        {
            if (connection != null) return connection;

            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<Stock>();

            if(await connection.Table<Stock>().CountAsync() == 0)
            {
                await connection.InsertAllAsync(fakeData);
            };
            return connection;
        }

        public async Task<List<Stock>> GetAll()
        {
            var connection = await GetConnection();
            return await connection.Table<Stock>().ToListAsync();
        }

        public async Task<Stock> Get(int id)
        {
            var connection = await GetConnection();
            return await connection.Table<Stock>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Stock data)
        {
            var connection = await GetConnection();
            await connection.UpdateAsync(data);
        }

        private readonly List<Stock> fakeData = new()
        {
            new Stock()
            {
                Name ="T-Shirt",
                Count = 2,
                Price = 100,
                SellPrice = 115,
                Type = "XXL"
            },
            new Stock()
            {
                Name ="Pants",
                Count = 1,
                Price = 50,
                SellPrice = 53,
                Type = "M"
            }
        };
    }
}
