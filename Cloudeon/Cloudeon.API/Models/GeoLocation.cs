using System.Net;
using System.Security.AccessControl;

namespace Cloudeon.API.Models
{
    public class GeoLocation
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int Speed { get; set; }
        public DateTime TimeRecorded { get; set; }=DateTime.Now;
        public Vehicle Vehicle { get; set; }
    }
}
