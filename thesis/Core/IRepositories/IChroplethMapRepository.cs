using DomainLayer.Models.ViewModels;

namespace thesis.Core.IRepositories
{
    public interface IChroplethMapRepository
    {
        public ChroplethMapViewModel GetChroplethData(string display);
    }
}
