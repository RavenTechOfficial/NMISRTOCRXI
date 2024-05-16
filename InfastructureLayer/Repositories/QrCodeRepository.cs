using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class QrCodeRepository : Repository<QrCode>, IQrCodeRepository
	{
		private readonly AppDbContext _context;

		public QrCodeRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(QrCode entity)
		{
			_context.Update(entity);
		}
	}
}
