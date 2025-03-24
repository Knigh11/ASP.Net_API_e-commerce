using API_demo.DataLayers.Context;
using API_demo.DataLayers.Interfaces;
using API_demo.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace API_demo.DataLayers.SQL
{
    public class ProductDAL : ICommonDAL<Product>
    {
        private readonly ApplicationDbContext _context;
        public ProductDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Product data)
        {
            await _context.Products.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.ProductID;

        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Products.FindAsync(id);
            if (data == null)
            {
                return false; // Không tìm thấy dữ liệu để xóa
            }

            _context.Products.Remove(data);
            await _context.SaveChangesAsync();
            return true; // Xóa thành công
        }

        public async Task<IEnumerable<Product>> List() => await _context.Products.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<Product>> Search(string SearchValue) => await _context.Products.Where(c => c.ProductName.ToLower().Contains(SearchValue.ToLower())).ToListAsync();

        public async Task<bool> Update(Product data)
        {
            var product = await _context.Products.FindAsync(data.ProductID);
            if (product == null) return false;
            else
            {
                product.ProductName = data.ProductName;
                product.SupplierID = data.SupplierID;
                product.Price = data.Price;
                product.ProductDescription = data.ProductDescription;
                product.Photo = data.Photo;
                product.IsSelling = data.IsSelling;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
