using System.ComponentModel.DataAnnotations;
using static EMI.Transversal.Enums.Enums;

namespace EMI.Application.DTO.User.Request
{
    public class CreateUserRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public RoleTypesEnum Role { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
