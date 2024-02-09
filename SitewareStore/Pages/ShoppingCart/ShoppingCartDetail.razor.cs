using Microsoft.AspNetCore.Components;
using SitewareStore.Data;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Pages.ShoppingCart
{
    public partial class ShoppingCartDetail : ComponentBase
    {
        [Inject]
        private UserShoppingCartService UserCartService { get; set; }

        [Inject]
        private IInitializeShoppingCartService CartInitializationService { get; set; }

        [Inject]
        private IUpdateShoppingCartItemService UpdateShoppingCartItemService { get; set; }

        [Inject]
        private IDeleteShoppingCartItemService DeleteShoppingCartItemService { get; set; }

        [Inject]
        private IGetShoppingCartService GetShoppingCartService { get; set; }

        [Inject]
        private IChangeShoppingCartStatusService ChangeShoppingCartStatusService { get; set; }

        [Parameter]
        public string CurrentCartId { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool saving = false;

        private ShoppingCartDTO currentCart = null;

        protected override async Task OnInitializedAsync()
        {
            await GetCurrentCart();
        }

        private async Task GetCurrentCart()
        {
            InternalResponse<ShoppingCartDTO> response;

            if (string.IsNullOrEmpty(CurrentCartId))
                response = await UserCartService.GetCurrent(CartInitializationService.Execute);
            else
                response = await GetShoppingCartService.Execute(Guid.Parse(CurrentCartId));

            if (response.IsSuccess())
            {
                currentCart = response.Single;

                if (!string.IsNullOrEmpty(CurrentCartId))
                    UserCartService.Save(response.Single);
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }

            StateHasChanged();
        }

        private async Task UpdateItem(Guid itemId, bool isDelete)
        {
            saving = true;
            StateHasChanged();

            int quantity = 0;
            if (!isDelete)
            {
                var currentItem = currentCart.Items.FirstOrDefault(x => x.Id.Equals(itemId));
                if (currentItem != null)
                    quantity = currentItem.Quantity;
            }

            InternalResponse<ShoppingCartDTO> response;
            if (quantity == 0)
                response = await DeleteShoppingCartItemService.Execute(new DeleteShoppingCartItemRequest(currentCart.Id, itemId));
            else
                response = await UpdateShoppingCartItemService.Execute(new UpdateShoppingCartItemRequest(currentCart.Id, itemId, quantity));

            if (response.IsSuccess())
            {
                currentCart = response.Single;
                UserCartService.Save(response.Single);
                alertControl = new KeyValuePair<bool, string>(false, response.Message);
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }

            saving = false;
            StateHasChanged();
        }

        private void ContinueShopping() =>
            Navigator.NavigateTo("/");

        private void GoBack() =>
            Navigator.NavigateTo("/cart/dashboard");

        private async Task FinalizeShop()
        {
            saving = true;
            StateHasChanged();

            var response = await ChangeShoppingCartStatusService.Execute(new ChangeShoppingCartStatusRequest(currentCart.Id, ShoppingCartStatus.Finished));
            if (response.IsSuccess())
            {
                currentCart = response.Single;
                UserCartService.Save(response.Single);
                alertControl = new KeyValuePair<bool, string>(false, response.Message);
                Navigator.NavigateTo("/cart/dashboard");
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }

            saving = false;
            StateHasChanged();
        }
    }
}
