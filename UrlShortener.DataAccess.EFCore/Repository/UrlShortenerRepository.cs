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
        private readonly UrlShortenerDbContext _context;

        public UrlShortenerRepository(UrlShortenerDbContext context)
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

        public async Task<UrlShortenerEnity> GetByurlShortenerGUID(string urlShortenerGUID)
        {
            return await _context.UrlShortenerEnity
                .FirstOrDefaultAsync(x => x.ShortestUrl == urlShortenerGUID);
        }

        public async Task<List<UrlShortenerEnity>> GetAll()
        {
            return await _context.UrlShortenerEnity.Where(x => x.IsDelete == false).ToListAsync();
        }

        public async Task<UrlShortenerEnity> GetByMainUrl(string mainUrl)
        {
            return await _context.UrlShortenerEnity
                   .FirstOrDefaultAsync(x => x.MainUrl == mainUrl); 
        }
    }
}
