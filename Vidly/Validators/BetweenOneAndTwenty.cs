using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Validators
{
    public class BetweenOneAndTwenty : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock > 0 && movie.NumberInStock <= 20)
                return ValidationResult.Success;
            else
                return new ValidationResult("Number In Stock must range from 1 to 20.");
             
        }
    }
}