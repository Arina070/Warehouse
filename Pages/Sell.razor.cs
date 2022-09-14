using Microsoft.AspNetCore.Components;

namespace Warehouse.Pages
{
    public partial class Sell
    {
        private Data.Models.Stock stockItem = new();
        private Data.Models.Sale saleData = new();

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            stockItem = await stockRepository.Get(int.Parse(Id));
            saleData = new()
            {
                Name = stockItem.Name,
                Price = stockItem.Price,
                ChequePrice = stockItem.SellPrice,
                Count = stockItem.Count,
            };
        }

        private async Task Save()
        {
            await saleRepository.Insert(saleData);

            stockItem.Count -= saleData.Count;
            await stockRepository.Update(stockItem);

            navigationManager.NavigateTo("stock", true);
        }
    }     
}
