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

        public async Task Add(Stock data)
        {
            var connection = await GetConnection();
            await connection.InsertAsync(data);
        }

        public async Task Delete(int dataId)
        {
            var connection = await GetConnection();
            var data = await connection.Table<Stock>().FirstOrDefaultAsync(x => x.Id == dataId);
            if (data != null)
            {
                await connection.DeleteAsync(data);
            }
        }
    }
}
