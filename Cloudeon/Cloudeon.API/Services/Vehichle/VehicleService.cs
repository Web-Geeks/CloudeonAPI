using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using AutoMapper;
using Cloudeon.API.Data;
using Cloudeon.API.Dtos.Vehicle;
using Cloudeon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloudeon.API.Services.Vehicle
{
    public class VehicleService : IVechicleService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string GetUserName() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        public VehicleService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<List<GetVehicleDto>>> GetAllVehicles()
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleDto>>();
            var dbVehicles = await _context.Vehicles.ToListAsync();
            serviceResponse.Data = dbVehicles.Select(v => _mapper.Map<GetVehicleDto>(v)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVehicleDto>> GetVehicleById(int id)
        {
            var serviceResponse = new ServiceResponse<GetVehicleDto>();
            var dbVehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
            serviceResponse.Data = _mapper.Map<GetVehicleDto>(dbVehicle);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVehicleDto>>> AddVehicle(AddVehicleDto newVehicle)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleDto>>();
            Models.Vehicle vehicle = _mapper.Map<Models.Vehicle>(newVehicle);
            vehicle.UserCreated = GetUserName();
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Vehicles.Select(v => _mapper.Map<GetVehicleDto>(v)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVehicleDto>> UpdateVehicle(UpdateVehicleDto updatedVehicle)
        {
            var serviceResponse = new ServiceResponse<GetVehicleDto>();

            try
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == updatedVehicle.Id);
                vehicle.Registration = updatedVehicle.Registration;
                vehicle.Model=updatedVehicle.Model;
                vehicle.Make=updatedVehicle.Make;

                await _context.SaveChangesAsync();

            }
           
            catch (Exception e)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVehicleDto>>> DeleteVehicle(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleDto>>();
            try
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

                if (vehicle!=null)
                {
                    _context.Vehicles.Remove(vehicle);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Vehicles.Select(v => _mapper.Map<GetVehicleDto>(v)).ToList();
                    
                }
                else
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Vehicle Not Found";
                }
            }
            catch (Exception e)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;

        }


       
    }
}
