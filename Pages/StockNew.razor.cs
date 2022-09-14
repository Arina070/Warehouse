using Microsoft.AspNetCore.Components;

namespace Warehouse.Pages
{
    public partial class StockNew
    {
        [Parameter]
        public string Id { get; set; }

        private Data.Models.Stock exisingItem = new();

        private Data.Models.Stock item = new();

        public bool Prefilled => Id != null;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                exisingItem = await stockRepository.Get(int.Parse(Id));
                item = new()
                {
                    Name = exisingItem.Name,
                    Type = exisingItem.Type,
                    Price = exisingItem.Price,
                    Count = 1,
                    SellPrice = exisingItem.SellPrice
                };
            }
        }

        private async Task Save()
        {
            if (item.Price == exisingItem.Price
                && item.SellPrice == exisingItem.SellPrice)
            {
                exisingItem.Count += item.Count;
                await stockRepository.Update(exisingItem);
            }
            else
            {
                await stockRepository.Add(item);
            }

            navigationManager.NavigateTo("stock", true);
        }
    }
}
