using thesis.Core.ViewModel;
using thesis.Data.Enum;

namespace thesis.Core.IRepositories
{
    public interface IGeolocationRepository
    {
        GeolocationViewModel Getgeolocation(GeolocationViewModel geolocation);
    }
}
