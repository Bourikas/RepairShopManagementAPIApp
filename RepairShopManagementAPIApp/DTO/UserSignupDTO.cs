﻿using RepairShopManagementAPIApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RepairShopManagementAPIApp.DTO
{
    public class UserSignupDTO
    {
        [StringLength(100, ErrorMessage = "Email should not exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W).{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, " +
            "one lowercase letter, one digit, and one special character.")]
        public string? Password { get; set; }

        [StringLength(50, ErrorMessage = "Firstname should not exceed 50 characters.")]
        public string? Firstname { get; set; }

        [StringLength(50, ErrorMessage = "Lastname should not exceed 50 characters.")]
        public string? Lastname { get; set; }

        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid user role.")]
        public UserRole? UserRole { get; set; }

        public override string? ToString()
        {
            return $"{Firstname} {Lastname} {Email} {Password} {UserRole!.Value}";
        }
    }
}
