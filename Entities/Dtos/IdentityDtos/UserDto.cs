using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "User Name is required.")]
        public string? UserName { get; init; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; init; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}