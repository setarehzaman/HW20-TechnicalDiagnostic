﻿

namespace App.Domain.Core.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Request> Requests { get; set; }

    }
}
