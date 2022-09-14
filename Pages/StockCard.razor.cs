using Microsoft.AspNetCore.Components;
using Warehouse.Data;

namespace Warehouse.Pages
{
    public partial class StockCard
    {
        [Parameter]
        public Data.Models.Stock Item { get; set; }

        private async Task Delete(int id)
        {
            await stockRepository.Delete(id);
        }
    }
}
