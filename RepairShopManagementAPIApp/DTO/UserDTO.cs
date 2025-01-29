using RepairShopManagementAPIApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RepairShopManagementAPIApp.DTO
{
    public class UserDTO
    {
        [NotNull]
        public int Id { get; set; }

        [StringLength(50, MinimumLength =2, ErrorMessage = "Firstname must be between 2 and 50 charachters.")]
        public string? Firstname { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 and 50 charachters.")]
        public string? Lastname { get; set; }

        [NotNull]
        [StringLength(100, ErrorMessage = "Email must not exceed 100 charachters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength =8, ErrorMessage ="Password must be at least 8 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
