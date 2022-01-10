using Cloudeon.API.Dtos.Vehicle;
using Cloudeon.API.Models;
using Cloudeon.API.Services.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloudeon.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVechicleService _vechicleService;

        public VehicleController(IVechicleService vechicleService)
        {
            _vechicleService = vechicleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetVehicleDto>>>> Get()
        {
            return Ok(await _vechicleService.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVehicleDto>>> GetSingle(int id)
        {
            return Ok(await _vechicleService.GetVehicleById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVehicleDto>>>> AddVehicle(AddVehicleDto newVehicle)
        {
            return Ok(await _vechicleService.AddVehicle(newVehicle));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetVehicleDto>>> UpdateVehicle(UpdateVehicleDto updatedVehicle)
        {
            var response = await _vechicleService.UpdateVehicle(updatedVehicle);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetVehicleDto>>>> Delete(int id)
        {
            var response = await _vechicleService.DeleteVehicle(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);

        }
    }
}
