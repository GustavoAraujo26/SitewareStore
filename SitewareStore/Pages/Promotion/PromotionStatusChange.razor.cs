using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Service.Contracts.Promotion;

namespace SitewareStore.Pages.Promotion
{
    public partial class PromotionStatusChange : ComponentBase
    {
        [Inject]
        private IGetPromotionService GetPromotionService { get; set; }

        [Inject]
        private IChangePromotionStatusService ChangePromotionStatusService { get; set; }

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

        private async Task ChangeStatus()
        {
            saving = true;
            StateHasChanged();

            var response = await ChangePromotionStatusService.Execute(new ChangePromotionStatusRequest(PromotionDto.Id, GetNewStatus()));
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
            if (PromotionDto.Status == StatusType.Active)
                return StatusType.Cancelled;
            else
                return StatusType.Active;
        }

        private void GoBack() =>
            Navigator.NavigateTo("/promotion/dashboard");
    }
}
