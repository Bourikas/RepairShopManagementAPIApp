using System.ComponentModel.DataAnnotations;

namespace RepairShopManagementAPIApp.DTO
{
    public class UserLoginDTO
    {
        [StringLength(100, ErrorMessage = "Email must not exceed 100 charachters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
        public string? Password { get; set; }

        public bool KeepLoggedIn { get; set; }
    }
}
