
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleModelId { get; set; }
        [Required(ErrorMessage = "سال تولید خودرو الزامی است")]
        public int Year { get; set; }
        [Required(ErrorMessage = "شرکت سازنده خودرو الزامی است")]
        public string Brand { get; set; }
        public VehicleModel Model { get; set; }
        public List<Request> VehicleRequests { get; set; }
    }
}
        