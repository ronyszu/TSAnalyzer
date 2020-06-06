using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
    public class Parameter :IEntity
    {
        public Parameter(){}

        public int Id { get;set;}

        public double Value { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AnalysisId { get; set; }

        [ForeignKey("AnalysisId")]
        public virtual Analysis Analysis  { get; set; }

    }
}
