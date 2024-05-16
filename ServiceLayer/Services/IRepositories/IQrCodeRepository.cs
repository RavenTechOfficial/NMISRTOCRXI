using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IQrCodeRepository : IRepository<QrCode>
	{
		void Update(QrCode entity);
	}
}