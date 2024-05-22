using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAntemortemRepository : IRepository<Antemortem>
    {
        void Update(Antemortem entity);
    }
}
