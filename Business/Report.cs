using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
    public class Report : IEntity
    {
        public Report(){}

        public int Id { get;set;}

        public string Name { get; set; }


    }
}
