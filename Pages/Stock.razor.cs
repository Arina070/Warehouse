using Microsoft.Maui.Controls.Handlers.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Pages
{
    public partial class Stock
    {
        private List<Warehouse.Data.Models.Stock> data;

        protected override async Task OnInitializedAsync()
        {
            data = await stockRepository.GetAll();
        }

    }
}
