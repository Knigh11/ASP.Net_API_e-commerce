using API_demo.DataLayers.Context;
using API_demo.DataLayers.Interfaces;
using API_demo.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace API_demo.DataLayers.SQL
{
    public class ProvinceDAL : ISimpleSelectDAL<Province>
    {
        private readonly ApplicationDbContext _context;
        public ProvinceDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Province>> List() => await _context.Provinces.AsNoTracking().ToListAsync();
    }
}
