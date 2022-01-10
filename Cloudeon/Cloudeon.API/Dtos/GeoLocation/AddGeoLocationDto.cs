namespace Cloudeon.API.Dtos.GeoLocation
{
    public class AddGeoLocationDto
    {
        public int VehicleId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int Speed { get; set; }
       
    }
}
