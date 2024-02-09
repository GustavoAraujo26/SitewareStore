using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Pages.Promotion
{
    public partial class PromotionRegister : ComponentBase
    {
        [Inject]
        private ISavePromotionService SavePromotionService { get; set; }

        [Inject]
        private IGetPromotionService GetPromotionService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Parameter]
        public string CurrentPromotionId { get; set; }

        private SavePromotionRequest SaveRequest { get; set; }

        private List<KeyValuePair<int, string>> typeList = PromotionType.FullPriceByQuantity.ListOptions();

        private int? typeSelected = null;

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        private bool blockEdit = false;
        private bool saving = false;

        protected override async Task OnInitializedAsync()
        {
            SaveRequest = new SavePromotionRequest();

            await ConfigureRequest();
        }

        private void OnTypeChange()
        {
            if (typeSelected == 0)
                return;

            SaveRequest.Type = (PromotionType)typeSelected;

            StateHasChanged();
        }

        private async Task ConfigureRequest()
        {
            if (string.IsNullOrEmpty(CurrentPromotionId))
            {
                SaveRequest = new SavePromotionRequest();
                blockEdit = false;
                StateHasChanged();
                return;
            }

            var response = await GetPromotionService.Execute(Guid.Parse(CurrentPromotionId));
            if (response.IsSuccess())
            {
                var dto = response.Single;

                SaveRequest = new SavePromotionRequest(dto.Id, dto.Observation, dto.Type, dto.CutQuantity, dto.Percentage, dto.Price);
                typeSelected = (int)dto.Type;
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

            var response = await SavePromotionService.Execute(SaveRequest);
            if (response.IsSuccess())
            {
                alertControl = new KeyValuePair<bool, string>(false, string.Empty);

                Navigator.NavigateTo("/promotion/dashboard");
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
