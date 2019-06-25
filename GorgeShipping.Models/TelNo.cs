using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GorgeShipping.Models
{
    public class TelNo
    {
        public Guid id { get; set; }
        public string TelNumber { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get;set;}

        public bool IsVerify { get; set; }

    }
}
