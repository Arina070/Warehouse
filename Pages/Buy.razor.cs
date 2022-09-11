using Microsoft.AspNetCore.Components;
using Warehouse.Data;

namespace Warehouse.Pages
{
    public partial class Buy
    {
        private Data.Models.Stock stockItem;
        private Data.Models.Stock newStockItem;

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            newStockItem = new();

            if (int.TryParse(Id, out int id))
            {
                stockItem = await stockRepository.Get(id);
                newStockItem = new()
                {
                    Name = stockItem.Name,
                    Price = stockItem.Price,
                    Color = stockItem.Color,
                    Size = stockItem.Size,
                    SellPrice = stockItem.SellPrice,
                    Count = stockItem.Count,
                };
            }
        }

        private async Task OnSave()
        {
            if (int.TryParse(Id, out int id))
            {
                stockItem = await stockRepository.Get(id);
                if (IsSameStockItem(stockItem, newStockItem))
                {
                    stockItem.Count += newStockItem.Count;
                    await stockRepository.Update(stockItem);

                    return;
                }
            };

            await stockRepository.Add(newStockItem);

            //TODO: Navigate back
        }

        private bool IsSameStockItem(Data.Models.Stock stockItem, Data.Models.Stock newStockItem)
        {
            return stockItem.Name.Trim() == newStockItem.Name.Trim()
                || stockItem.Price == newStockItem.Price
                || stockItem.Color == newStockItem.Color
                || stockItem.Size == newStockItem.Size
                || stockItem.SellPrice == newStockItem.SellPrice;
        }
    }
}
