using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace thesis.Repositories
{
    public class ReceivingReportRepository : IReceivingReportRepository
    {
        private readonly AppDbContext _context;

        public ReceivingReportRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<ReceivingReport>> GetAllRReportsAsync()
        {
            //return await _context.receivingReports
            //    .Include(r  => r.receivingReportMeatEstablishments)
            //    .Include(r => r.Receiving)
            //    .ToListAsync();
            throw new NotImplementedException();
        }
        public int GetTotalOfHeads()
        {
            //return _context.receivingReports.Sum(r => r.NoOfHeads);
            throw new NotImplementedException();
        }
    }
}
