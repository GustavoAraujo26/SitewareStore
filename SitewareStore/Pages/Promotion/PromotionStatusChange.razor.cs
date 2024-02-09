using Microsoft.AspNetCore.Components;
using SitewareStore.Domain.Services.Promotion;

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
    }
}
