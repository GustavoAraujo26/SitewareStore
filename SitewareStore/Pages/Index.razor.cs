using Microsoft.AspNetCore.Components;
using SitewareStore.Data;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Services.ShoppingCart;

namespace SitewareStore.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private IListActiveProductService ListActiveProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Inject]
        private UserShoppingCartService UserCartService { get; set; }

        [Inject]
        private IInitializeShoppingCartService CartInitializationService { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private List<Domain.Entities.Product> activeProductList = new List<Domain.Entities.Product>();

        protected override async Task OnInitializedAsync()
        {
            await GetCurrentCart();
            await GetActiveProducts();
        }

        private async Task GetCurrentCart()
        {
            var response = await UserCartService.GetCurrent(CartInitializationService.Execute);
            if (!response.IsSuccess())
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(false, response.Message);
            }

            StateHasChanged();
        }

        private async Task GetActiveProducts()
        {
            var response = await ListActiveProductService.Execute();
            if (!response.IsSuccess())
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }
            else
            {
                activeProductList = response.List;
            }

            StateHasChanged();
        }

        private void GoBuy(Guid productId) =>
            Navigator.NavigateTo($"/product/buy/{productId}");
    }
}
