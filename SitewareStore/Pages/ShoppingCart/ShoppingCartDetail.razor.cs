using Microsoft.AspNetCore.Components;

namespace SitewareStore.Pages.ShoppingCart
{
    public partial class ShoppingCartDetail : ComponentBase
    {
        [Parameter]
        public string CurrentCartId { get; set; }
    }
}
