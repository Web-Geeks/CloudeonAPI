using Cloudeon.API.Dtos.Vehicle;
using Cloudeon.API.Models;

namespace Cloudeon.API.Services.Vehicle
{
    public interface IVechicleService
    {
        Task<ServiceResponse<List<GetVehicleDto>>> GetAllVehicles();
        Task<ServiceResponse<GetVehicleDto>> GetVehicleById(int id);
        Task<ServiceResponse<List<GetVehicleDto>>> AddVehicle(AddVehicleDto newVehicle);
        Task<ServiceResponse<GetVehicleDto>> UpdateVehicle(UpdateVehicleDto updatedVehicle);
        Task<ServiceResponse<List<GetVehicleDto>>> DeleteVehicle(int id);

    }
}
