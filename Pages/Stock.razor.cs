namespace Warehouse.Pages
{
    public partial class Stock
    {
        private List<Data.Models.Stock> data;

        protected override async Task OnInitializedAsync()
        {
            refreshService.RefreshRequested += async () =>
            {
                await RefreshMe();
            };

            await GetData();
        }

        private async Task RefreshMe()
        {
            await GetData();
            StateHasChanged();
        }

        private async Task GetData()
        {
            data = await stockRepository.GetAll();
        }
    }
}
