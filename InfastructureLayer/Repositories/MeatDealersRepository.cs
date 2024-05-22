using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class MeatDealersRepository : Repository<MeatDealers>, IMeatDealersRepository
    {
        private readonly AppDbContext _context;

        public MeatDealersRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(MeatDealers entity)
        {
            _context.Update(entity);
        }
    }
}
