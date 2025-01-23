using App.Domain.Core.enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.RazorPages.Models
{
    public class CreateRequest
    {
        public int Id { get; set; }

        [DisplayName ("کدملی")]
        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "کد ملی فقط باید شامل اعداد باشد.")]
        public string OwnerCode { get; set; }

        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "شماره تماس الزامی است.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید 11 رقم باشد.")]
        public string MobileNumber { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("آدرس")]
        public string Address { get; set; }


        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;

    }
}
