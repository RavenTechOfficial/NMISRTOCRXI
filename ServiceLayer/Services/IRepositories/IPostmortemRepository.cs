using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPostmortemRepository : IRepository<Postmortem>
    {
        void Update(Postmortem entity);
    }
}
