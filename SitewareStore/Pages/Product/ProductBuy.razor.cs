using Microsoft.AspNetCore.Components;
using SitewareStore.Data;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Services.ShoppingCart;

namespace SitewareStore.Pages.Product
{
    public partial class ProductBuy : ComponentBase
    {
        [Inject]
        private IListActiveProductService ListActiveProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Inject]
        private UserShoppingCartService UserCartService { get; set; }

        [Inject]
        private IInitializeShoppingCartService CartInitializationService { get; set; }

        [Inject]
        private IAddShoppingCartItemService AddCartItemService { get; set; }

        [Parameter]
        public string CurrentProductId { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool saving = false;

        private Domain.Entities.Product product = null;
        private ShoppingCartDTO currentCart = null;

        private int productQuantity = 0;
        private decimal totalPrice = 0;

        protected override async Task OnInitializedAsync()
        {
            await GetCurrentCart();
            await GetProduct();
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
                currentCart = response.Single;
            }

            StateHasChanged();
        }

        private async Task GetProduct()
        {
            var id = Guid.Parse(CurrentProductId);

            var response = await ListActiveProductService.Execute();
            if (!response.IsSuccess())
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }
            else
            {
                product = response.List.FirstOrDefault(x => x.Id.Equals(id));
            }

            StateHasChanged();
        }

        private void CalculatePrice()
        {
            if (product.PromotionApplied == null)
            {
                totalPrice = decimal.Round(productQuantity * product.Price, 2);
            }
            else
            {
                totalPrice = product.PromotionApplied.CalculateFinalPrice(productQuantity, product.Price);
            }

            StateHasChanged();
        }

        private async Task Buy()
        {
            saving = true;
            StateHasChanged();

            var response = await AddCartItemService.Execute(new AddShoppingCartItemRequest(currentCart.Id, product.Id, productQuantity));
            if (response.IsSuccess())
            {
                UserCartService.Save(response.Single);
                Navigator.NavigateTo($"/cart/detail/{currentCart.Id}");
            }
            else
            {
                saving = false;
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
                StateHasChanged();
            }
        }

        private void GoBack() =>
            Navigator.NavigateTo("/");
    }
}
