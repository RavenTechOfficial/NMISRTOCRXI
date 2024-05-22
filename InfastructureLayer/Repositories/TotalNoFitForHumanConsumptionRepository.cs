using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class TotalNoFitForHumanConsumptionRepository : Repository<TotalNoFitForHumanConsumptions>, ITotalNoFitForHumanConsumptionRepository
    {
        private readonly AppDbContext _context;

        public TotalNoFitForHumanConsumptionRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(TotalNoFitForHumanConsumptions entity)
        {
            _context.Update(entity);
        }
    }
}
