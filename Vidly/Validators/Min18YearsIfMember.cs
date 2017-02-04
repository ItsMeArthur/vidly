using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Validators
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MembershipType.Unknown || 
                customer.MemberShipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            int age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to apply to membership.");
        }
    }
}