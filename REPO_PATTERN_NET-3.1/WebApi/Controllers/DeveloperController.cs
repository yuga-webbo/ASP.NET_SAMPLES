using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("DeveloperPolicy")]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetDevelopers")]
        public IActionResult GetPopularDevelopers([FromQuery]int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);

        }
        [HttpPost("AddDevelopers")]
        public IActionResult AddDeveloperAndProject(DeveloperDto developerdata)
        {
            var developer = new Developer
            {
                Followers = developerdata.Followers,
                Name = developerdata.Name
            };
            var project = new Project
            {
                Name = developerdata.ProjectName
            };
            _unitOfWork.Developers.Add(developer);
            _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();
            return Ok();

        }
    }
}