using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace Freedom.Template.Domain
{
    public class Project : Entity<Guid>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid? ProjectTypeId { get; set; }

        public ProjectType ProjectType { get; set; }
    }
}
