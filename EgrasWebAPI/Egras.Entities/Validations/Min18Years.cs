using System.ComponentModel.DataAnnotations;

namespace Egras.Entities
{
    public class Min18Years:ValidationAttribute
    {
        //public override ValidationResult IsValid(object value,ValidationContext validationcontext)
        //{
        //    var student = (Student)AutoMapper.ValidationContext.ObjectInstance;

        //    if (student.DateofBirth == null)
        //        return new ValidationResult("Date of Birth is required.");

        //    var age = DateTime.Today.Year - student.DateofBirth.Year;

        //    return (age >= 18)
        //        ? ValidationResult.Success
        //        : new ValidationResult("Student should be at least 18 years old.");
        //}
    }
}
