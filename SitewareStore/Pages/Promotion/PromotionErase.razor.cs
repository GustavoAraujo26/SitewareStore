using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Services.Promotion;

namespace SitewareStore.Pages.Promotion
{
    public partial class PromotionErase : ComponentBase
    {
        [Inject]
        private IGetPromotionService GetPromotionService { get; set; }

        [Inject]
        private IDeletePromotionService DeletePromotionService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Parameter]
        public string CurrentPromotionId { get; set; }

        private PromotionDTO PromotionDto { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool saving = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadPromotion();
        }

        private async Task LoadPromotion()
        {
            var response = await GetPromotionService.Execute(Guid.Parse(CurrentPromotionId));
            if (response.IsSuccess())
            {
                PromotionDto = response.Single;
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

            var response = await DeletePromotionService.Execute(Guid.Parse(CurrentPromotionId));
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
            Navigator.NavigateTo("/promotion/dashboard");
    }
}
