namespace EmployeesProgresiveWASM.Data
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? Avatar { get; set; }
        public DateTime? LastModified { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is EmployeeModel other)
            {
                return Id == other.Id &&
                       FirstName == other.FirstName &&
                       LastName == other.LastName &&
                       Email == other.Email &&
                       Department == other.Department &&
                       Avatar == other.Avatar &&
                       LastModified == other.LastModified;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, Email, Department, Avatar, LastModified);
        }
    }
}
