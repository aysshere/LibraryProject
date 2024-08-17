using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            // Default values
            Status = true; // or false, depending on your desired default status
            Gender = 0;    // Assuming 0 represents an undefined or default gender
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public byte Gender { get; set; }
    }
}
