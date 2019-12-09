using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidiling.Models
{
    public class Min18Customer :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Uknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthday == null)
                return  new ValidationResult("The BirthDate is Required");
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("customer should be at least 18 years old"); 
        }
    }
}