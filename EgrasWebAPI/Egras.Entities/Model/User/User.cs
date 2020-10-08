using System;
using System.ComponentModel.DataAnnotations;

namespace Egras.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Login ID is required")]
        [StringLength(60, ErrorMessage = "Login ID can't be longer than 60 characters")]
        public string LoginID { get; set; }

        [StringLength(5, ErrorMessage = "DeptCode can't be longer than 5 characters")]
        public string DeptCode { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, ErrorMessage = "First Name can't be longer than 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, ErrorMessage = "Last Name can't be longer than 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(10, ErrorMessage = "Gender can't be longer than 10 characters")]
        public string Gender { get; set; }
        
        [Required(ErrorMessage = "DOB is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Marital Status is required")]
        [StringLength(5, ErrorMessage = "Marital Status can't be longer than 5 characters")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(60, ErrorMessage = "Address can't be longer than 60 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(20, ErrorMessage = "City can't be longer than 20 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int Country { get; set; }


        [Required(ErrorMessage = "Mobile is required")]
        [StringLength(10, ErrorMessage = "Mobile no can't be longer than 10 characters")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "PinCode is required")]
        [StringLength(6, ErrorMessage = "Pin Code can't be longer than 6 characters")]
        public string PinCode { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "Password can't be longer than 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Verification Code is required")]
        [StringLength(20, ErrorMessage = "Verification Code can't be longer than 20 characters")]
        public string VerificationCode { get; set; }

        [Required(ErrorMessage = "AttemptNumber Code is required")]
        [StringLength(10, ErrorMessage = "Attempt Number can't be longer than 10 characters")]
        public string AttemptNumber { get; set; }
        public string Identity { get; set; }

        [Required(ErrorMessage = "UserType Code is required")]
        public int UserType { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
}
