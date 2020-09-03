using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web_Lab_Milevskaya_90311.DAL.Entities
{
    public class ApplicationUser:IdentityUser

    {
        public byte[] AvatarImage { get; set; }
    }
}
