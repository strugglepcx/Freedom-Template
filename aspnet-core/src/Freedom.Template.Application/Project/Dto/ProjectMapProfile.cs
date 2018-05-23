using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Freedom.Template.Project.Dto
{
    public class ProjectMapProfile : Profile
    {
        public ProjectMapProfile()
        {
            this.CreateMap<Domain.Project, GetProjectDto>().ForMember(t => t.ProjectTypeName,
                m => m.MapFrom(s => s.ProjectType == null ? "未知" : s.ProjectType.Name));
        }
    }
}
