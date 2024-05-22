using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class PassedForSlaughterRepository : Repository<PassedForSlaughter>, IPassedForSlaughterRepository
    {
        private readonly AppDbContext _context;

        public PassedForSlaughterRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(PassedForSlaughter entity)
        {
            _context.Update(entity);
        }
    }
}
