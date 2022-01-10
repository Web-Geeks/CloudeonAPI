using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Cloudeon.API.Data;
using Cloudeon.API.Dtos.GeoLocation;
using Cloudeon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloudeon.API.Services.Location
{
    public class GeoLocationService : IGeoLocationService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GeoLocationService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetGetLocationsDto>>> AddNewLocation(AddGeoLocationDto newGeoLocation)
        {

            var serviceResponse = new ServiceResponse<List<GetGetLocationsDto>>();
            GeoLocation geoLocation = _mapper.Map<GeoLocation>(newGeoLocation);
           _context.GeoLocations.Add(geoLocation);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.GeoLocations.Where(v => v.Vehicle.Id == newGeoLocation.VehicleId)
                .Select(v => _mapper.Map<GetGetLocationsDto>(v)).ToListAsync();

            return serviceResponse;
        }
    }
}
    