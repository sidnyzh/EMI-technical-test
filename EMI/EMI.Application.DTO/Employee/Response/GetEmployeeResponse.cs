namespace EMI.Application.DTO.Employee.Response
{
    public class GetEmployeeResponse
    {
        public int EmployeeId { get; set; }

        public int Department { get; set; }

        public string Name { get; set; } = null!;

        public int CurrentPosition { get; set; }

        public decimal Salary { get; set; }
    }
}
