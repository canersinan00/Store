using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        public String? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String? Password { get; init; }

        [Required(ErrorMessage ="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public String? ConfirmPassword { get; init; }
    }
}