using Microsoft.AspNetCore.Mvc;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Promotion;

namespace SitewareStore.Application.Controllers
{
    [Route("api/promotion")]
    [ApiController]
    public class PromotionApiController : ControllerBase
    {
        private readonly IChangePromotionStatusService changeStatusService;
        private readonly IDeletePromotionService deleteService;
        private readonly IGetPromotionService searchService;
        private readonly IListActivePromotionService listActiveService;
        private readonly IListPromotionService listAllService;
        private readonly ISavePromotionService saveService;

        public PromotionApiController(IChangePromotionStatusService changeStatusService, 
            IDeletePromotionService deleteService, IGetPromotionService searchService, 
            IListActivePromotionService listActiveService, 
            IListPromotionService listAllService, 
            ISavePromotionService saveService)
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
        public async Task<IActionResult> ChangeStatus([FromBody] ChangePromotionStatusRequest request)
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
        public async Task<IActionResult> Save([FromBody] SavePromotionRequest request)
        {
            var response = await saveService.Execute(request);
            return StatusCode((int)response.Status, response);
        }
    }
}
