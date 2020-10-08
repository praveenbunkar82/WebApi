using System;

namespace Egras.Entities
{
    public class UserDto
    {
        //public int UserId { get; set; }
        //public string LoginID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string MobilePhone { get; set; }
        public string PinCode { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string Question { get; set; }
    }
}
