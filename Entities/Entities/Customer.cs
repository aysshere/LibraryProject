using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Customer: BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public byte Gender { get; set; }
        public string PasswordHash { get; set; }
        public bool Status { get; set; }
        



        
        public ICollection<BookRent> BookRents { get; set; }

    }
}
