using System;

namespace Egras.Entities
{
    public class AuthenticateDto
    {
        public string Username { get; set; }
        public string ErrorCode { get; set; }
        public Int64 UserID { get; set; }
        public int UserType { get; set; }
        public string Userflag { get; set; }
        public string TokenString { get; set; }
    }
}
