using Cloudeon.API.Dtos.GeoLocation;
using Cloudeon.API.Dtos.Vehicle;
using Cloudeon.API.Models;
using Cloudeon.API.Services.Location;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloudeon.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GeoLocationController : ControllerBase
    {
        private readonly IGeoLocationService _geoLocationService;

        public GeoLocationController(IGeoLocationService geoLocationService)
        {
            _geoLocationService = geoLocationService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetVehicleDto>>> AddLocation(AddGeoLocationDto newLocation)
        {
            return Ok(await _geoLocationService.AddNewLocation(newLocation));
        }
    }
}

