using DomainLayer.Models.ViewModels;

namespace ServiceLayer.Services.IRepositories
{
    public interface IChroplethMapRepository
    {
        public ChroplethMapViewModel GetChroplethData(string display);
    }
}
