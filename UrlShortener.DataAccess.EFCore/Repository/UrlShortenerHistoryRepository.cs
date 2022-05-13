using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.DataAccess.EFCore.Repository
{
    public class UrlShortenerHistoryRepository : IUrlShortenerHistoryRepository
    {
        private readonly UrlShrtenerDbContext _context;

        public UrlShortenerHistoryRepository(UrlShrtenerDbContext context)
        {
            _context = context;
        }

        public async Task<long> Add(UrlShortenerHistoryEnity urlShortenerHistory)
        {
            _context.UrlShortenerHistoryEnity.Add(urlShortenerHistory);
            return await _context.SaveChangesAsync();
        }

        public async Task<UrlShortenerHistoryEnity> Get(long id)
        {
            return await _context.UrlShortenerHistoryEnity
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<UrlShortenerHistoryEnity> GetAll()
        {
            return _context.UrlShortenerHistoryEnity.Where(x => x.IsDelete == false);
        }
    }
}
