using Microsoft.AspNetCore.Components;

namespace Warehouse.Pages
{
    public partial class StockNew
    {
        [Parameter]
        public string Id { get; set; }

        private Data.Models.Stock item = new();

        public bool Prefilled => Id != null;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                item = await stockRepository.Get(int.Parse(Id));
            }
        }

        private async Task Save()
        {
            item.Id = 0;
            await stockRepository.Add(item);
            navigationManager.NavigateTo("stock", true);
        }
    }
}
