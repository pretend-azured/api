using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Azured.Web.Api.Models;
using Microsoft.Extensions.Logging;

namespace Azured.Web.Api.Controllers
{
    [Route("projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _repository;        
        private readonly ILogger<ProjectController> _logger;
        
        public ProjectController(IProjectRepository repository, ILogger<ProjectController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        public IEnumerable<Project> GetAll()
        {
            return _repository.GetProjects();
        }

        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetById(string id)
        {
            var project = _repository.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return new ObjectResult(project);
        }
    }
}
