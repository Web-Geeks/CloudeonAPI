using Cloudeon.API.Dtos.GeoLocation;
using Cloudeon.API.Models;

namespace Cloudeon.API.Dtos.Vehicle
{
    public class GetVehicleDto
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public List<GetGetLocationsDto> Locations { get; set; }
    }
}
