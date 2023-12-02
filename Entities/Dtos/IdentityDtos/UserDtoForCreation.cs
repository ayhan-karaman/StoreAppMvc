using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public record UserDtoForCreation : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }
    }
}