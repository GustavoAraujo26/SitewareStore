using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Services.Promotion;

namespace SitewareStore.Pages.Product
{
    public partial class ProductRegister : ComponentBase
    {
        [Inject]
        private ISaveProductService SaveProductService { get; set; }

        [Inject]
        private IGetProductService GetProductService { get; set; }

        [Inject]
        private IListActivePromotionService ListActivePromotionService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Parameter]
        public string CurrentProductId { get; set; }

        private SaveProductRequest SaveRequest { get; set; }

        private List<KeyValuePair<Guid, string>> activePromotionList = new List<KeyValuePair<Guid, string>>();

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool blockEdit = false;
        private bool saving = false;

        protected override async Task OnInitializedAsync()
        {
            SaveRequest = new SaveProductRequest();

            await ConfigureActivePromotions();
            await ConfigureRequest();
        }

        private async Task ConfigureActivePromotions()
        {
            var response = await ListActivePromotionService.Execute();
            if (response.IsSuccess())
            {
                if (response.List != null)
                {
                    activePromotionList = response.List.Select(x => new KeyValuePair<Guid, string>(x.Id, x.ExibitionText)).ToList();
                }
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }

            StateHasChanged();
        }

        private async Task ConfigureRequest()
        {
            if (string.IsNullOrEmpty(CurrentProductId))
            {
                SaveRequest = new SaveProductRequest();
                blockEdit = false;
                StateHasChanged();
                return;
            }

            var response = await GetProductService.Execute(Guid.Parse(CurrentProductId));
            if (response.IsSuccess())
            {
                var dto = response.Single;

                SaveRequest = new SaveProductRequest(dto.Id, dto.Name, dto.Price, dto.PromotionId);
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);
            }

            blockEdit = true;
            StateHasChanged();
        }

        private async Task Save()
        {
            blockEdit = true;
            saving = true;
            alertControl = new KeyValuePair<bool, string>(false, string.Empty);
            StateHasChanged();

            var response = await SaveProductService.Execute(SaveRequest);
            if (response.IsSuccess())
            {
                alertControl = new KeyValuePair<bool, string>(false, string.Empty);

                Navigator.NavigateTo("/product/dashboard");
            }
            else
            {
                alertControl = new KeyValuePair<bool, string>(true, response.Message);

                blockEdit = false;
                saving = false;
                StateHasChanged();
            }
        }

        private void EnableEdit()
        {
            blockEdit = false;
            StateHasChanged();
        }
    }
}
