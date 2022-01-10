namespace Cloudeon.API.Dtos.GeoLocation
{
    public class GetGetLocationsDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int Speed { get; set; }
        
    }
}
