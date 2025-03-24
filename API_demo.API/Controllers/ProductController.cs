using API_demo.BusinessLayers;
using API_demo.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace API_demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly CommonDataService _dataService;
        public ProductController(CommonDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet(Name = "GetListProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetList() => Ok(await _dataService.GetListProducct());
        [HttpPost(Name = "PostProduct")]
        public async Task<IActionResult> Add(Product data) => Ok(await _dataService.AddProduct(data));
        [HttpPut(Name = "UpdataProduct")]
        public async Task<bool> Update(Product data) => await _dataService.UpdateProduct(data);
        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(int id) => Ok(await _dataService.DeleteProduct(id));
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string SearchValue)
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
            {
                return BadRequest("Search value cannot be empty.");
            }
            SearchValue = SearchValue.Trim().ToLower(CultureInfo.InvariantCulture);
            var product = await _dataService.SearchProduct(SearchValue);

            if (product == null || !product.Any())
            {
                return NotFound("No categories found.");
            }

            return Ok(product);
        }

    }
}
