using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class TSMetadataDbConfiguration: IEntityTypeConfiguration<TSMetadata>
    {
        public TSMetadataDbConfiguration(){}


        public void Configure(EntityTypeBuilder<TSMetadata> builder){

            builder.ToTable("TSMetadata");
            builder.Property(x=>x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.StartTime).HasColumnName("ts_start");
            builder.Property(x => x.EndTime).HasColumnName("ts_end");
            builder.HasKey(x=>x.Id);

        }
    }
}
