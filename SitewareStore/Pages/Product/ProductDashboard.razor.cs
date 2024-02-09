using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;
using SitewareStore.Service.Contracts.Promotion;

namespace SitewareStore.Pages.Product
{
    public partial class ProductDashboard : ComponentBase
    {
        [Inject]
        private IListProductService ListProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        private InternalResponse<ProductListDTO> listResponse { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        protected override async Task OnInitializedAsync()
        {
            await LoadResponse();
        }

        private void NavigateToEdition(Guid id) =>
            Navigator.NavigateTo($"/product/register/{id}");

        private void NavigateToErase(Guid id) =>
            Navigator.NavigateTo($"/product/delete/{id}");

        private void NavigateToStatusChange(Guid id) =>
            Navigator.NavigateTo($"/product/change-status/{id}");

        private async Task LoadResponse()
        {
            listResponse = await ListProductService.Execute();
            alertControl = new KeyValuePair<bool, string>(!listResponse.IsSuccess(), listResponse.Message);
        }
    }
}
