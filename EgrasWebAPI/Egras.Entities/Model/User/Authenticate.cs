using System;
using System.ComponentModel.DataAnnotations;

namespace Egras.Entities
{
    public class Authenticate
    {
        [Required]
        public string Username { get; set; }
        public string ErrorCode { get; set; }
        [Required]
        public string Rnd { get; set; }
        [Required]
        public string Password { get; set; }
        public Int64 UserID { get; set; }
        public int UserType { get; set; }
        public string IPAddress { get; set; }
        public string Userflag { get; set; }
        public string SHAPassword { get; set; }
        public string RoleName { get; set; }
        public UserRole UserRole { get; set; }
        //public string TokenString { get; set; }

    }
}
