namespace Cloudeon.API.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public string Make { get; set; }
        public string  Model { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public string UserCreated { get; set; }
        public List<GeoLocation> Locations { get; set; }
    }
}
