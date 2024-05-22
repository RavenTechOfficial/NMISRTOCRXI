using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Repositories
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly AppDbContext _context;

        public ResultsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result> GetResultDetails(int uid)
        {
            
            var res = await _context.Results.FirstOrDefaultAsync(p => p.Id == uid);

            return res;
        }
    }
}
