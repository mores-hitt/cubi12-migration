using ApiGateway.Src.DTOs.Models;
using ApiGateway.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Src.Controllers
{
    public class CareersController : BaseApiController
    {
        private readonly ICareerService _careersService;

        public CareersController(ICareerService careersService)
        {
            _careersService = careersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CareerDto>>> GetCareers()
        {
            var careers = await _careersService.GetAll();
            return Ok(careers);
        }

    }

}