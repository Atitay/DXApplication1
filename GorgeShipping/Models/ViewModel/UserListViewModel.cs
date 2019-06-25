using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeShipping.Models.ViewModel
{
    public class UserListViewModel
    {
        public User Users { get; set; }
        public TelNo TelephoneNumbers { get; set; }
        public Address Addresses { get; set; }
    }
}
