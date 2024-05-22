using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class MeatEstablishmentRepository : Repository<MeatEstablishment>, IMeatEstablishmentRepository
    {
        private readonly AppDbContext _context;

        public MeatEstablishmentRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(MeatEstablishment entity)
        {
            _context.Update(entity);
        }
    }
}
