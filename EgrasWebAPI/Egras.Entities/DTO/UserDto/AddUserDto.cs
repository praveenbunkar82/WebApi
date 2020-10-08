namespace Egras.Entities
{
    public class AddUserDto : UserDto
    {
        public int userId { get; set; }
        public string LoginId { get; set; }
        public int DeptCode { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
        public string AttemptNumber { get; set; }
        public string UserType { get; set; }
        public string QuestionId { get; set; }
    }
}
