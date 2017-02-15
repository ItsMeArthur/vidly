using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Validators;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MemberShipType { get; set; } 

        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }

        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}