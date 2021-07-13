using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Data.Maps;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class TransportCompanyMap : BaseMap<TransportCompany>
    {
        public override void Configure(EntityTypeBuilder<TransportCompany> builder)
        {
            builder.ToTable("TransportCompany", "chs");

            base.Configure(builder);

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("BIT")
                .HasColumnName("fl_active");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("name");

            builder.Property(x => x.TrackingUrl)
                .IsRequired()
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("tracking_url");

            builder.Property(x => x.SiteUrl)
                .IsRequired()
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("site_url");

            builder.Property(x => x.ApiUrl)
                .IsRequired()
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("api_url");

            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasColumnType("VARCHAR(14)")
                .HasColumnName("cnpj");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(200)")
                .HasColumnName("email");

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("phone");

            builder.OwnsOne(x => x.Address,
                ad =>
                {
                    ad.Property(a => a.Street)
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)")
                        .HasColumnName("street");

                    ad.Property(a => a.ZipCode)
                        .IsRequired()
                        .HasColumnType("VARCHAR(16)")
                        .HasColumnName("zip_code");

                    ad.Property(a => a.Number)
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("number");

                    ad.Property(a => a.Complement)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("complement");

                    ad.Property(a => a.OpeningTime)
                        .HasColumnType("TIME")
                        .HasColumnName("opening_time");

                    ad.Property(a => a.ClosingTime)
                        .HasColumnType("TIME")
                        .HasColumnName("closing_time");
                }
            );
        }
    }
}
