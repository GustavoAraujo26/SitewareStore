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

        protected override async Task OnInitializedAsync()
        {
            listResponse = await ListPromotionService.Execute();
        }

        private void NavigateToEdition(Guid id) =>
            Navigator.NavigateTo($"/promotion/register/{id}");
    }
}
