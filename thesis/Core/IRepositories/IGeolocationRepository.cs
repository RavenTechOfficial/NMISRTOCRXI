using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;

namespace thesis.Core.IRepositories
{
    public interface IGeolocationRepository
    {
        GeolocationViewModel Getgeolocation(GeolocationViewModel geolocation);
    }
}
