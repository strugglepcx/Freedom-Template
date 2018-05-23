using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace Freedom.Template.Domain
{
    public class ProjectType : Entity<Guid>
    {
        public string Name { get; set; }

        public List<Project> Projects { get; set; }
    }
}
