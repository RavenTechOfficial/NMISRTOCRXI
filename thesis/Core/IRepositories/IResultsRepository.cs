using thesis.Models;

namespace thesis.Core.IRepositories
{
    public interface IResultsRepository
    {
        Task<Result> GetResultDetails(int uid);


    } 
}
