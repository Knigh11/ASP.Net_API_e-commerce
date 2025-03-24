using API_demo.BusinessLayers;
using API_demo.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace API_demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {

        private readonly CommonDataService _dataService;
        public ProvinceController(CommonDataService context)
        {
            _dataService = context;
        }
        [HttpGet(Name = "GetListProvince")]
        public async Task<ActionResult<Province>> GetList()
        {
            var province = await _dataService.GetListProvinces();
            return Ok(province);
        }
    }
}
