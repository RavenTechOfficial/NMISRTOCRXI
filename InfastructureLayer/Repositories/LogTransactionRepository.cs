using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class LogTransactionRepository : Repository<LogTransaction>, ILogTransactionRepository
	{
		private readonly AppDbContext _context;

		public LogTransactionRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(LogTransaction entity)
		{
			_context.Update(entity);
		}
	}
}
