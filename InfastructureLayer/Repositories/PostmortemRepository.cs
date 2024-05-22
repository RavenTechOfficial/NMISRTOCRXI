using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace NMISRTOCXI.Repositories
{
    public class PostmortemRepository : Repository<Postmortem>, IPostmortemRepository
    {
        private readonly AppDbContext _context;

        public PostmortemRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(Postmortem entity)
        {
            _context.Update(entity);
        }
    }
}
