using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class TSDataDbConfiguration: IEntityTypeConfiguration<TSData>
    {
        public TSDataDbConfiguration(){}


        public void Configure(EntityTypeBuilder<TSData> builder){


            builder.ToTable("TSData");
            builder.Property(x=>x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Timestamp).HasColumnName("timestamp");
            builder.Property(x => x.Value).HasColumnName("value");
            builder.Property(x => x.SecondaryValue).HasColumnName("secondary_value");
            builder.Property(x => x.TertiaryValue).HasColumnName("tertiary_value");
            builder.Property(x => x.QuaternaryValue).HasColumnName("quaternary_value");
            builder.Property(x => x.TSMetadataId).HasColumnName("ts_metadata_fk").IsRequired();


            builder.HasKey(x=>x.Id);

        }
    }
}
