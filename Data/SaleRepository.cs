using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Models;

namespace Warehouse.Data
{
    internal class SaleRepository
    {
        private readonly string _dbPath;

        public SaleRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private SQLiteAsyncConnection connection;

        private async Task<SQLiteAsyncConnection> GetConnection()
        {
            if (connection != null) return connection;

            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<Sale>();

            return connection;
        }

        public async Task Insert(Sale data)
        {
            var connection = await GetConnection();
            await connection.InsertAsync(data);
        }
    }
}
