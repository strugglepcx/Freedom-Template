using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace Freedom.Template.Project.Dto
{
    public class GetProjectDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ProjectTypeName { get; set; }
    }
}
