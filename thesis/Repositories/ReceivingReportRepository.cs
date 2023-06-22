using Microsoft.EntityFrameworkCore;
using thesis.Core.IRepositories;
using thesis.Data;
using thesis.Models;

namespace thesis.Repositories
{
    public class ReceivingReportRepository : IReceivingReportRepository
    {
        private readonly thesisContext _context;

        public ReceivingReportRepository(thesisContext context)
        {
            _context = context;
        }
        public async Task<ICollection<ReceivingReport>> GetAllRReportsAsync()
        {
            return await _context.receivingReports
                .Include(r  => r.receivingReportMeatEstablishments)
                .Include(r => r.Receiving)
                .ToListAsync();
        }
        public int GetTotalOfHeads()
        {
            return _context.receivingReports.Sum(r => r.NoOfHeads);
        }
    }
}
