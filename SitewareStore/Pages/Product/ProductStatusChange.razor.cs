using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Product;

namespace SitewareStore.Pages.Product
{
    public partial class ProductStatusChange : ComponentBase
    {
        [Inject]
        private IGetProductService GetProductService { get; set; }

        [Inject]
        private IChangeProductStatusService ChangeProductStatusService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Parameter]
        public string CurrentProductId { get; set; }

        private ProductDTO ProductDto { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool saving = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadPromotion();
        }

        private async Task LoadPromotion()
        {
            var response = await GetProductService.Execute(Guid.Parse(CurrentProductId));
            if (response.IsSuccess())
            {
                ProductDto = response.Single;
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }

            StateHasChanged();
        }

        private async Task ChangeStatus()
        {
            saving = true;
            StateHasChanged();

            var response = await ChangeProductStatusService.Execute(new ChangeProductStatusRequest(ProductDto.Id, GetNewStatus()));
            if (response.IsSuccess())
            {
                GoBack();
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
                saving = false;
                StateHasChanged();
            }
        }

        private StatusType GetNewStatus()
        {
            if (ProductDto.Status == StatusType.Active)
                return StatusType.Cancelled;
            else
                return StatusType.Active;
        }

        private void GoBack() =>
            Navigator.NavigateTo("/product/dashboard");
    }
}
