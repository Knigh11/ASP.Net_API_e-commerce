using API_demo.DataLayers.Context;
using API_demo.DataLayers.Interfaces;
using API_demo.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace API_demo.DataLayers.SQL
{
    public class CategoryDAL : ICommonDAL<Category>
    {
        private readonly ApplicationDbContext _context;

        public CategoryDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Category data)
        {
            await _context.Categories.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.CategoryID;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                return false; // Không tìm thấy dữ liệu để xóa
            }

            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
            return true; // Xóa thành công
        }

        public async Task<IEnumerable<Category>> Search(string SearchValue)
        {
            return await _context.Categories
                .Where(c => c.CategoryName.ToLower().Contains(SearchValue.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> List() => await _context.Categories.AsNoTracking().ToListAsync();

        public async Task<bool> Update(Category data)
        {
            var category = await _context.Categories.FindAsync(data.CategoryID);
            if (category == null) return false;
            else
            {
                category.CategoryName = data.CategoryName;
                category.Description = data.Description;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
