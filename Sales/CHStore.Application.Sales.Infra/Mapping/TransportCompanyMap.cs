using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class TransportCompanyMap : IEntityTypeConfiguration<TransportCompany>
    {
        public void Configure(EntityTypeBuilder<TransportCompany> builder)
        {
            builder.ToTable("TransportCompany");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("BIT")
                .HasColumnName("FL_Active");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("Name");

            builder.Property(x => x.TrackingUrl)
                .IsRequired()
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("TrackingUrl");

            builder.Property(x => x.WebSiteUrl)
                .IsRequired()
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("WebSiteUrl");

            builder.Property(x => x.ApiUrl)
                .IsRequired()
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("ApiUrl");

            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasColumnType("VARCHAR(14)")
                .HasColumnName("CNPJ");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("Email");

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("Phone");

            builder.OwnsOne(x => x.Address,
                ad =>
                {
                    ad.Property(a => a.Street)
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)")
                        .HasColumnName("Street");
                    
                    ad.Property(a => a.ZipCode)
                        .IsRequired()
                        .HasColumnType("VARCHAR(16)")
                        .HasColumnName("ZipCode");
                    
                    ad.Property(a => a.Number)
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("Number");
                    
                    ad.Property(a => a.Complement)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Complement");
                    
                    ad.Property(a => a.OpeningTime)
                        .HasColumnType("TIME")
                        .HasColumnName("OpeningTime");

                    ad.Property(a => a.ClosingTime)
                        .HasColumnType("TIME")
                        .HasColumnName("ClosingTime");
                }
            );
        }
    }
}
