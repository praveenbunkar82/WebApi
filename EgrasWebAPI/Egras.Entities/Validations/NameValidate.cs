using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Egras.Entities
{
    public class NameValidate : Attribute, IModelValidator
    {
        //[NameValidate(NotAllowed = new string[] { "Osama Bin Laden", "Saddam Hussain", "Mohammed Gaddafi" }, ErrorMessage = "You cannot apply for the Job")]
        //public string Name { get; set; }
        public string[] NotAllowed { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            if (NotAllowed.Contains(context.Model as string))
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}
