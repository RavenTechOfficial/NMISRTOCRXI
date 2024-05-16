using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class DriverRepository : Repository<Driver>, IDriverRepository
	{
		private readonly AppDbContext _context;

		public DriverRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Driver entity)
		{
			_context.Update(entity);
		}
	}
}
