namespace CHStore.Application.Core.Filters
{
    public class SearchEmployeeFilter
    {
        public long EmployeeId { get; set; }
        public bool OnlyActives { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
