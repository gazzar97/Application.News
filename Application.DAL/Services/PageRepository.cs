using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Business_Logic.Contracts;
using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Application.DAL.Services
{
    public class PageRepository : IPageRepository
    {
        private readonly ApplicationDBContext _context;
        public PageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Page>> GetAll()
        {
            return await _context.Pages.AsNoTracking().ToListAsync();
                
        }
    }
}
