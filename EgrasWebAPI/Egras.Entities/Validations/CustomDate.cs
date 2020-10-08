using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Egras.Entities
{
    //public class CustomDate : ValidationAttribute
    //{
    //    ////[CustomAdmissionDate(ErrorMessage = "Admission Date must be less than or equal to Today's Date.")]
    //    ////public DateTime AdmissionDate { get; set; }
    //    //public override bool IsValid(object value)
    //    //{
    //    //    DateTime datetime = Convert.ToDateTime(value);
    //    //    return datetime <= DateTime.Now;
    //    //}
    //}
    public class CustomDate : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            if (Convert.ToDateTime(context.Model) > DateTime.Now)
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", "Date of birth can not be in future") };
            }
            else if (Convert.ToDateTime(context.Model) < new DateTime(1980, 1, 1))
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", "Date of birth can not be befor 1980") };
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}
