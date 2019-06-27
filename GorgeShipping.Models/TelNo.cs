using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GorgeShipping.Models
{
    public class TelNo
    {
        public Guid id { get; set; }
      
        [Display(Name = "Telephone Number")]
        public string TelNumber { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get;set;}

        public bool IsVerify { get; set; }
        public bool IsDefault { get; set; }

    }
}
