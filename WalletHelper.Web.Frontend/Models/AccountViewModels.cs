using System.ComponentModel.DataAnnotations;

namespace WalletHelper.Web.Frontend.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayWithResource(ResourceFieldName = "ChangePasswordPartial.CurrentPassword")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayWithResource(ResourceFieldName = "ChangePasswordPartial.NewPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayWithResource(ResourceFieldName = "ChangePasswordPartial.NewPasswordConfirm")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [DisplayWithResource(ResourceFieldName="LoginView.UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayWithResource(ResourceFieldName = "LoginView.Password")]
        public string Password { get; set; }

        [DisplayWithResource(ResourceFieldName = "LoginView.RememberMe")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [DisplayWithResource(ResourceFieldName = "Register.UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayWithResource(ResourceFieldName = "Register.Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayWithResource(ResourceFieldName = "Register.ConfirmPassword")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
