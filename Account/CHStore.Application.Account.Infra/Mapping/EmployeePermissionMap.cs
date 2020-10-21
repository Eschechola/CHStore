using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Account.Infra.Mapping
{
    class EmployeePermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
