﻿using App.Domain.Core.enums;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entities
{
    public class Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن شماره پلاک الزامی است ")]
        public string PlateNumber { get; set; }

        [Required(ErrorMessage = "شماره تماس الزامی است.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید 11 رقم باشد.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "کد ملی فقط باید شامل اعداد باشد.")]
        public string OwnerCode { get; set; }

        [Required(ErrorMessage = "آدرس الزامی است.")]
        public string Address { get; set; }
        public DateTime DateRequested { get; set; }
        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;  
        [Required(ErrorMessage = "سال تولید خودرو الزامی است")]
        public int VehicleCreationYear { get; set; }
        [Required(ErrorMessage = "شرکت سازنده خودرو الزامی است")]
        public string Brand { get; set; }
        public int VehicleModelId  { get; set; }
        public VehicleModel VehicleModel { get; set; }
    }
}
