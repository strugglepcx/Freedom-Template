using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Freedom.Template.Project.Dto;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Template.Project
{
    public class ProjectAppService : TemplateAppServiceBase, IProjectAppService
    {
        private readonly IRepository<Domain.Project, Guid> _projectRepository;

        public ProjectAppService(IRepository<Domain.Project, Guid> projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public async Task<List<GetProjectDto>> GetProjects(GetProjectsInput input)
        {
            var projectList = await _projectRepository.GetAllIncluding(t => t.ProjectType).ToListAsync();
            return ObjectMapper.Map<List<GetProjectDto>>(projectList);
        }

        public async Task<List<GetProjectDto>> GetProjectsByTypeName(GetProjectsByTypeInput input)
        {
            var projectList =
                await _projectRepository.GetAllIncluding(t => t.ProjectType)
                    .WhereIf(!string.IsNullOrWhiteSpace(input.ProjectTypeName),
                        t => t.ProjectType.Name.Contains(input.ProjectTypeName)).ToListAsync();
            return ObjectMapper.Map<List<GetProjectDto>>(projectList);
        }
    }
}
