using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Services.Promotion;

namespace SitewareStore.Pages.Product
{
    public partial class ProductErase : ComponentBase
    {
        [Inject]
        private IGetProductService GetProductService { get; set; }

        [Inject]
        private IDeleteProductService DeleteProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Parameter]
        public string CurrentProductId { get; set; }

        private ProductDTO ProductDto { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool saving = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadProduct();
        }

        private async Task LoadProduct()
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

        private async Task Erase()
        {
            saving = true;
            StateHasChanged();

            var response = await DeleteProductService.Execute(Guid.Parse(CurrentProductId));
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

        private void GoBack() =>
            Navigator.NavigateTo("/product/dashboard");
    }
}
