using API_demo.DataLayers.Context;
using API_demo.DataLayers.Interfaces;
using API_demo.DomainModels;

namespace API_demo.BusinessLayers
{
    public class CommonDataService
    {
        private readonly ICommonDAL<Category> _categoryDB;
        private readonly ICommonDAL<Product> _productDB;
        private readonly ISimpleSelectDAL<Province> _provinceDB;

        // Sử dụng dependency injection để nhận ApplicationDbContext
        public CommonDataService(ApplicationDbContext dbContext)
        {
            _categoryDB = new DataLayers.SQL.CategoryDAL(dbContext);
            _productDB = new DataLayers.SQL.ProductDAL(dbContext);
            _provinceDB = new DataLayers.SQL.ProvinceDAL(dbContext);
        }

        // Phương thức để lấy danh sách categories
        public async Task<IEnumerable<Category>> GetListCategories() => await _categoryDB.List();
        public async Task<IEnumerable<Category>> SearchCategory(string SearchValue) { return await _categoryDB.Search(SearchValue); }
        //Create và bảng Categories một object Category
        public async Task<int> AddCategory(Category data) { return await _categoryDB.Add(data); }
        //Xoá một dữ liệu
        public async Task<bool> DeleteCategory(int id) { return await _categoryDB.Delete(id); }
        //Update dữ liệu với dữ liệu vào là một object category
        public async Task<bool> UpdateCategory(Category data) { return await _categoryDB.Update(data); }
        //lấy danh sách của các thành phó
        public async Task<IEnumerable<Province>> GetListProvinces() => await _provinceDB.List();
        //Product
        //Lấy danh sách sản phẩm
        public async Task<IEnumerable<Product>> GetListProducct() => await _productDB.List();
        public async Task<IEnumerable<Product>> SearchProduct(string SearchValue) => await _productDB.Search(SearchValue);
        public async Task<int> AddProduct(Product data) => await _productDB.Add(data);
        public async Task<bool> DeleteProduct(int id) => await _productDB.Delete(id);
        public async Task<bool> UpdateProduct(Product data) => await _productDB.Update(data);
    }
}