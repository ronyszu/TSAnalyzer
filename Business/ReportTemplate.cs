using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
    public class ReportTemplate : IEntity
    {
        public ReportTemplate() { }

        public int Id { get; set; }

        public int IndicatorId { get; set; }

        public int ReportId { get; set; }

        [ForeignKey("IndicatorId")]
        public virtual Indicator Indicator { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }

    }
}
