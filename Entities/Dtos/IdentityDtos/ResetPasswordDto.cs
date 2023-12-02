using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public record ResetPasswordDto
    {
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be match.")]
        public string? ConfirmPassword { get; set; }
    }
}