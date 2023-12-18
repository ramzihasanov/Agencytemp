using System.ComponentModel.DataAnnotations;

namespace Agency.Areas.ViewModels
{
    public class MemberRegisterViewModel
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]      
        public string AgainPassword { get; set; }
    }
}
