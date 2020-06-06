using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business
{
    public class Analysis : IEntity
    {
        public Analysis(){}

        public int Id { get;set;}

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
