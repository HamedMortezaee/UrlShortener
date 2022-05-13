using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.DataAccess.EFCore.Repository
{
    public class UrlShortenerRepository : IUrlShortenerRepository
    {
        private readonly UrlShrtenerDbContext _context;

        public UrlShortenerRepository(UrlShrtenerDbContext context)
        {
            _context = context;
        }


        public async Task<long> Add(UrlShortenerEnity urlShortener)
        {
            _context.UrlShortenerEnity.Add(urlShortener);
            return await _context.SaveChangesAsync();
        }

        public async Task Edit(UrlShortenerEnity urlShortener)
        {
            _context.UrlShortenerEnity.Attach(urlShortener);
            _context.Entry(urlShortener).Property(x => x.MainUrl).IsModified = true;
            _context.Entry(urlShortener).Property(x => x.ShortestUrl).IsModified = true;
            _context.Entry(urlShortener).Property(x => x.UpdateDate).IsModified = true;
            _context.Entry(urlShortener).Property(x => x.UpdateUserId).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<UrlShortenerEnity> Get(long id)
        {
            return await _context.UrlShortenerEnity
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<UrlShortenerEnity> GetAll()
        {
            return _context.UrlShortenerEnity.Where(x => x.IsDelete == false);
        }

        public async Task<UrlShortenerEnity> GetByurlShortenerGUID(string urlShortenerGUID)
        {
            return await _context.UrlShortenerEnity
                .FirstOrDefaultAsync(x => x.UrlShortenerGUID == urlShortenerGUID);
        }
    }
}
