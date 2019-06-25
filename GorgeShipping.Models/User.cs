using System;
using System.Collections.Generic;

namespace GorgeShipping.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<TelNo> TelephoneNumbers { get; set; }
    }
}
