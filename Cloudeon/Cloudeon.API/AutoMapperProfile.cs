using AutoMapper;
using Cloudeon.API.Dtos.GeoLocation;
using Cloudeon.API.Dtos.Vehicle;
using Cloudeon.API.Models;


namespace Cloudeon.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, GetVehicleDto>();
            CreateMap<AddVehicleDto,Vehicle>();
          
            CreateMap<GeoLocation, GetGetLocationsDto>(); 
            CreateMap<AddGeoLocationDto,GeoLocation>();
        }
       
    }
}
