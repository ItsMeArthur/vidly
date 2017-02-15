using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Validators;

namespace Vidly.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDTO MemberShipType { get; set; }

        public byte MemberShipTypeId { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}