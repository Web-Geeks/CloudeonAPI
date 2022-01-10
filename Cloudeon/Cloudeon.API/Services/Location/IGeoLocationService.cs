using Cloudeon.API.Dtos.GeoLocation;
using Cloudeon.API.Models;

namespace Cloudeon.API.Services.Location
{
    public interface IGeoLocationService
    {
        Task<ServiceResponse<List<GetGetLocationsDto>>> AddNewLocation(AddGeoLocationDto newGeoLocation);
    }
}
