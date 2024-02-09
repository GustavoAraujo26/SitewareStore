using Microsoft.AspNetCore.Mvc;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.ShoppingCart;

namespace SitewareStore.Application.Controllers
{
    [Route("api/shopping-cart")]
    [ApiController]
    public class ShoppingCartApiController : ControllerBase
    {
        private readonly IAddShoppingCartItemService addItemService;
        private readonly IChangeShoppingCartStatusService changeStatusService;
        private readonly IDeleteShoppingCartItemService deleteItemService;
        private readonly IGetShoppingCartService searchService;
        private readonly IInitializeShoppingCartService initializationService;
        private readonly IListShoppingCartService listAllService;
        private readonly IUpdateShoppingCartItemService updateItemService;

        public ShoppingCartApiController(IAddShoppingCartItemService addItemService, 
            IChangeShoppingCartStatusService changeStatusService, IDeleteShoppingCartItemService deleteItemService, 
            IGetShoppingCartService searchService, IInitializeShoppingCartService initializationService, 
            IListShoppingCartService listAllService, IUpdateShoppingCartItemService updateItemService)
        {
            this.addItemService = addItemService;
            this.changeStatusService = changeStatusService;
            this.deleteItemService = deleteItemService;
            this.searchService = searchService;
            this.initializationService = initializationService;
            this.listAllService = listAllService;
            this.updateItemService = updateItemService;
        }

        [HttpPost]
        [Route("item")]
        public async Task<IActionResult> AddItem([FromBody] AddShoppingCartItemRequest request)
        {
            var response = await addItemService.Execute(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost]
        [Route("change-status")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeShoppingCartStatusRequest request)
        {
            var response = await changeStatusService.Execute(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete]
        [Route("item")]
        public async Task<IActionResult> Delete([FromBody] DeleteShoppingCartItemRequest request)
        {
            var response = await deleteItemService.Execute(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await searchService.Execute(id);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet]
        [Route("initialize")]
        public async Task<IActionResult> Initialization()
        {
            var response = await initializationService.Execute(Guid.NewGuid());
            return StatusCode((int)response.Status, response);
        }

        [HttpGet]
        [Route("list/all")]
        public async Task<IActionResult> ListAll()
        {
            var response = await listAllService.Execute();
            return StatusCode((int)response.Status, response);
        }

        [HttpPut]
        [Route("item")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateShoppingCartItemRequest request)
        {
            var response = await updateItemService.Execute(request);
            return StatusCode((int)response.Status, response);
        }
    }
}
