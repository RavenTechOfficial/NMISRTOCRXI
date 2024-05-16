using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class VehicleInfoRepository : Repository<VehicleInfo>, IVehicleInfoRepository
	{
		private readonly AppDbContext _context;

		public VehicleInfoRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(VehicleInfo entity)
		{
			_context.Update(entity);
		}
	}
}
