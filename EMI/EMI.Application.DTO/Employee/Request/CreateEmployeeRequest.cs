using System.ComponentModel.DataAnnotations;

namespace EMI.Application.DTO.Employee.Request
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int Department { get; set; }
        [Required]
        public int CurrentPosition { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
