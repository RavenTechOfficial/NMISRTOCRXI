using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class MeatInspectionReportRepository : Repository<MeatInspectionReport>, IMeatInspectionReportRepository
    {
        private readonly AppDbContext _context;

        public MeatInspectionReportRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(MeatInspectionReport entity)
        {
            _context.Update(entity);
        }
    }
}
