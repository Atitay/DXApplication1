using System;
using System.Collections.Generic;
using System.Linq;

namespace GorgeShipping.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<TelNo> TelephoneNumbers { get; set; }
        public virtual TelNo TelDefault => TelephoneNumbers?.Where(t => t.IsDefault).FirstOrDefault();  //many Phone, use default

    }
}
