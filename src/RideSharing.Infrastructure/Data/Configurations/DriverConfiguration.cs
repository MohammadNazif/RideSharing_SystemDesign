using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RideSharing.Domain.Entities;


    public class DriverLocationConfiguration : IEntityTypeConfiguration<DriverLocation>
    {
        public void Configure(EntityTypeBuilder<DriverLocation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Driver)
                   .WithOne(d => d.Location)
                   .HasForeignKey<DriverLocation>(x => x.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


