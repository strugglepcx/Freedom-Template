using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Freedom.Template.Project.Dto;

namespace Freedom.Template.Project
{
    public interface IProjectAppService
    {
        Task<List<GetProjectDto>> GetProjects(GetProjectsInput input);

        Task<List<GetProjectDto>> GetProjectsByTypeName(GetProjectsByTypeInput input);
    }
}
