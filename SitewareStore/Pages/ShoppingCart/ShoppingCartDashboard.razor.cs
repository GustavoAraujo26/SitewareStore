using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Pages.ShoppingCart
{
    public partial class ShoppingCartDashboard : ComponentBase
    {
        [Inject]
        private IListShoppingCartService ListShoppingCartService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        private InternalResponse<ShoppingCartListDTO> listResponse { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        protected override async Task OnInitializedAsync()
        {
            await LoadResponse();
        }

        private void NavigateToEdition(Guid id) =>
            Navigator.NavigateTo($"/cart/detail/{id}");

        private async Task LoadResponse()
        {
            listResponse = await ListShoppingCartService.Execute();
            alertControl = new KeyValuePair<bool, string>(!listResponse.IsSuccess(), listResponse.Message);
        }
    }
}
