using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public byte Gender { get; set; }
        public string PasswordHash { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;



        public virtual List<Book> Books { get; set; }

    }
}
