using System.Collections.Generic;

namespace Azured.Web.Api.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
        
        Project GetProject(string name);
    }
}