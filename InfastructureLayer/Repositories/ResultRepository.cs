using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class ResultRepository : Repository<Result>, IResultRepository
	{
		private readonly AppDbContext _context;

		public ResultRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Result entity)
		{
			_context.Update(entity);
		}
	}
}
