using ApiGateway.Src.DTOs.Models;
using ApiGateway.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Src.Controllers
{
    public class SubjectController : BaseApiController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("GetAllSubjects")]

        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAll();
            return Ok(subjects);
        }

        [HttpGet("GetAllSubjectRelationships")]
        public async Task<IActionResult> GetAllSubjectRelationships()
        {
            var relationships = await _subjectService.GetAllRelationships();
            return Ok(relationships);
        }

        [HttpGet("GetAllPrerequisites")]
        public async Task<IActionResult> GetAllPrerequisites()
        {
            var prerequisites = await _subjectService.GetAllPrerequisites();
            return Ok(prerequisites);
        }

        [HttpGet("GetAllPostRequisites")]
        public async Task<IActionResult> GetAllPostRequisites()
        {
            var postRequisites = await _subjectService.GetAllPostRequisites();
            return Ok(postRequisites);
        }

    }
}