using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Pages.Promotion
{
    public partial class PromotionDashboard : ComponentBase
    {
        [Inject]
        private IListPromotionService ListPromotionService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        private InternalResponse<PromotionListDTO> listResponse { get; set; }

        private KeyValuePair<bool, string> alertControl = new KeyValuePair<bool, string>(false, string.Empty);

        protected override async Task OnInitializedAsync()
        {
            await LoadResponse();
        }

        private void NavigateToEdition(Guid id) =>
            Navigator.NavigateTo($"/promotion/register/{id}");

        private void NavigateToErase(Guid id) =>
            Navigator.NavigateTo($"/promotion/delete/{id}");

        private void NavigateToStatusChange(Guid id) =>
            Navigator.NavigateTo($"/promotion/change-status/{id}");

        private async Task LoadResponse()
        {
            listResponse = await ListPromotionService.Execute();
            alertControl = new KeyValuePair<bool, string>(!listResponse.IsSuccess(), listResponse.Message);
        }
    }
}
