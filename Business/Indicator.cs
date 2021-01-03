using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
    public class Indicator : IEntity
    {
        public Indicator() { }

        public int Id { get; set; }

        public int TSMetadataId { get; set; }

        public int AnalysisId { get; set; }

        [ForeignKey("AnalysisId")]
        public virtual Analysis Analysis { get; set; }

        [ForeignKey("TSMetadataId")]
        public virtual TSMetadata TSMetadata { get; set; }

    }
}
