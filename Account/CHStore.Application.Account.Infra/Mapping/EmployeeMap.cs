using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Account.Infra.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
