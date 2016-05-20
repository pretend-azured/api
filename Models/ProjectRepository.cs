using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Azured.Web.Api.Models
{
    public sealed class ProjectRepository : IProjectRepository
    {
        private readonly ConcurrentDictionary<string, Project> _projects;
        
        private readonly ILogger<ProjectRepository> _logger;
        
        public ProjectRepository(ILogger<ProjectRepository> logger)
        {
            _logger = logger;
            
            _projects = new ConcurrentDictionary<string, Project>();
            string projectsFolder = @"Project\";
            foreach(DirectoryInfo directory in new DirectoryInfo(projectsFolder).GetDirectories())
            {
                string projectName = directory.Name;
                FileInfo metadataFile = directory.GetFiles("meta.json").SingleOrDefault();
                if (metadataFile != null)
                {
                    string metadataJson = File.ReadAllText(metadataFile.FullName);
                    ProjectMetadata metadata = JsonConvert.DeserializeObject<ProjectMetadata>(metadataJson);                    
                    projectName = metadata.Title;
                }
                Project project = new Project
                {
                    Id = directory.Name,
                    Name = projectName,
                    Sections = new Dictionary<string, string>()
                };
                foreach(FileInfo file in directory.GetFiles("*.md"))
                {
                    string sectionName = file.Name.Replace(".md", String.Empty);
                    string sectionContent = File.ReadAllText(file.FullName);
                    project.Sections.Add(sectionName, sectionContent);
                }
                _projects[project.Id] = project;
            }  
        }

        public Project GetProject(string name)
        {
            return _projects[name];
        }

        public IEnumerable<Project> GetProjects()
        {
            return _projects.Values;
        }
    }
}