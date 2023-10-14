using thesis.Core.ViewModel;

namespace thesis.Core.IRepositories
{
    public interface IChroplethMapRepository
    {
        public ChroplethMapViewModel GetChroplethData(string display);
    }
}
