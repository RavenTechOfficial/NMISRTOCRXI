using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;

namespace ServiceLayer.Services.IRepositories
{
    public interface IGeolocationRepository
    {
        GeolocationViewModel Getgeolocation(GeolocationViewModel geolocation);
    }
}
