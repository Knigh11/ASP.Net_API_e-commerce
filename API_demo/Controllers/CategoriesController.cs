using API_demo.BusinessLayers;
using API_demo.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace API_demo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly CommonDataService _dataService;
        public CategoriesController(ILogger<CategoriesController> logger, CommonDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetList()
        {
            var categories = await _dataService.GetListCategories();
            return Ok(categories);
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Category>>> SearchCategory(string SearchValue)
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
            {
                return BadRequest("Search value cannot be empty.");
            }
            SearchValue = SearchValue.Trim().ToLower(CultureInfo.InvariantCulture);
            var categories = await _dataService.SearchCategory(SearchValue);

            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }

            return Ok(categories);
        }
        [HttpPost(Name = "PostCategory")]
        public async Task<IActionResult> Add(Category data)
        {
            var id = await _dataService.AddCategory(data);
            return Ok(id);
        }
        [HttpPut(Name = "PutCategory")]
        public async Task<IActionResult> Update(Category data)
        {
            var status = await _dataService.UpdateCategory(data);
            return Ok(status);
        }
        [HttpDelete(Name = "DeleteCategory")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _dataService.DeleteCategory(id));
        }
    }
}
