using System.ComponentModel.DataAnnotations;

namespace Agency.Areas.ViewModels
{
    public class AdminLoginViewModel
    { 
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
