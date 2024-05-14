using Microsoft.EntityFrameworkCore;
using thesis.Core.IRepositories;
using thesis.Data;
using DomainLayer.Models;

namespace thesis.Repositories
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly thesisContext _context;

        public ResultsRepository(thesisContext context)
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
