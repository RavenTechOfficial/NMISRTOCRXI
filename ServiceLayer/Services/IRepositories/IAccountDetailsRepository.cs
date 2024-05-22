using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAccountDetailsRepository : IRepository<AccountDetails>
    {
        void Update(AccountDetails entity);
    }
}
