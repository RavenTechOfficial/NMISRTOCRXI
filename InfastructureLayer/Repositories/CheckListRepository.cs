using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
    public class CheckListRepository : Repository<CheckList>, ICheckListRepository
    {
        private readonly AppDbContext _context;

        public CheckListRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(CheckList entity)
        {
            _context.Update(entity);
        }
    }
}
