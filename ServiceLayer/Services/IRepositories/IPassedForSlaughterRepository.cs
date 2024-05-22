using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPassedForSlaughterRepository : IRepository<PassedForSlaughter>
    {
        void Update(PassedForSlaughter entity);
    }
}
