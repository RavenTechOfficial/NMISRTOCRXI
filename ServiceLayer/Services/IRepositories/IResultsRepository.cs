using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IResultsRepository
    {
        Task<Result> GetResultDetails(int uid);


    } 
}
