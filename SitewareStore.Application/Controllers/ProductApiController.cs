using Microsoft.AspNetCore.Mvc;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Product;

namespace SitewareStore.Application.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IChangeProductStatusService changeStatusService;
        private readonly IDeleteProductService deleteService;
        private readonly IGetProductService searchService;
        private readonly IListActiveProductService listActiveService;
        private readonly IListProductService listAllService;
        private readonly ISaveProductService saveService;

        public ProductApiController(IChangeProductStatusService changeStatusService, 
            IDeleteProductService deleteService, IGetProductService searchService, 
            IListActiveProductService listActiveService, IListProductService listAllService, 
            ISaveProductService saveService)
        {
            this.changeStatusService = changeStatusService;
            this.deleteService = deleteService;
            this.searchService = searchService;
            this.listActiveService = listActiveService;
            this.listAllService = listAllService;
            this.saveService = saveService;
        }

        [HttpPost]
        [Route("change-status")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeProductStatusRequest request)
        {
            var response = await changeStatusService.Execute(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await deleteService.Execute(id);
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
        [Route("list/active")]
        public async Task<IActionResult> ListActive()
        {
            var response = await listActiveService.Execute();
            return StatusCode((int)response.Status, response);
        }

        [HttpGet]
        [Route("list/all")]
        public async Task<IActionResult> ListAll()
        {
            var response = await listAllService.Execute();
            return StatusCode((int)response.Status, response);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody] SaveProductRequest request)
        {
            var response = await saveService.Execute(request);
            return StatusCode((int)response.Status, response);
        }
    }
}
