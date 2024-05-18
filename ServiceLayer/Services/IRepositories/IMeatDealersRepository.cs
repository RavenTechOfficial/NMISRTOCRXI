using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IMeatDealersRepository : IRepository<MeatDealers>
    {
        void Update(MeatDealers entity);
    }
}
