using ApiGateway.Src.DTOs.Models;
using ApiGateway.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Src.Controllers
{
    public class ResourcesController : BaseApiController
    {
        private readonly ILegacyService _legacyService;

        public ResourcesController(ILegacyService legacyService)
        {
            _legacyService = legacyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjectResources()
        {
            var subjectResources = await _legacyService.GetAllSubjectResources();
            return Ok(subjectResources);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetSubjectResourceById(int id)
        {
            var subjectResource = await _legacyService.GetSubjectResourceById(id);
            return Ok(subjectResource);
        }
    }
    
}