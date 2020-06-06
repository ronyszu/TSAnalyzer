using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class ParameterDbConfiguration: IEntityTypeConfiguration<Parameter>
    {
        public ParameterDbConfiguration(){}


        public void Configure(EntityTypeBuilder<Parameter> builder){


            builder.ToTable("Parameter");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Value).HasColumnName("value");
            builder.Property(x => x.Description).HasColumnName("description");

            builder.Property(x => x.AnalysisId).HasColumnName("analysis_fk").IsRequired();




        }
    }
}
