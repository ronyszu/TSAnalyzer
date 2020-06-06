using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
    public class TSData : IEntity
    {
        public TSData(){}

        public int Id { get;set;}

        public DateTime Timestamp { get; set; }

        public double Value { get; set; }

        public double SecondaryValue { get; set; }

        public double TertiaryValue { get; set; }

        public double QuaternaryValue { get; set; }

        public int TSMetadataId { get; set; }

        [ForeignKey("TSMetadataId")]
        public virtual TSMetadata TSMetadata  { get; set; }

    }
}
