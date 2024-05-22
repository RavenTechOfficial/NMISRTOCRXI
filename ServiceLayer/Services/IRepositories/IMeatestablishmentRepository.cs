using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IMeatEstablishmentRepository : IRepository<MeatEstablishment>
    {
        void Update(MeatEstablishment entity);
    }
}
