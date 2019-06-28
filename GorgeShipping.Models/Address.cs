using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GorgeShipping.Models
{
    public class Address
    {
        public Guid id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string AddressDetail { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }

    }
}
