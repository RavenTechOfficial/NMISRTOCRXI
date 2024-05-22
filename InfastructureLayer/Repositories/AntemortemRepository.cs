using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class AntemortemRepository : Repository<Antemortem>, IAntemortemRepository
    {
        private readonly AppDbContext _context;

        public AntemortemRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(Antemortem entity)
        {
            _context.Update(entity);
        }
    }
}
