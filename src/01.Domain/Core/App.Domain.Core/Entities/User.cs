
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Entities
{
    public class User : IdentityUser<int>
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }    
    }
}
