using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController(IVehicleModelAppService vehicleModelAppService,
        IConfiguration configuration) : ControllerBase
    {
        [HttpGet("GetAll")] 
        public async Task<List<VehicleModel>> GetAllModels([FromHeader] string apiKey,CancellationToken cancellationToken)
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var models = await vehicleModelAppService.GetAllVehicleModels(cancellationToken);
            return models;
        }

        [HttpGet("GetById/{id}")]
        public async Task<VehicleModel> GetVehicleModelById([FromHeader] string apiKey, int id,CancellationToken cancellation) 
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var model = await vehicleModelAppService.GetVehicleModel(id,cancellation);
            return model;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateModel([FromHeader] string apiKey,
            [FromBody] VehicleModelDto vehicleModelDto , CancellationToken cancellation)
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var model = new VehicleModel();
            model.Name = vehicleModelDto.Name;

            var result = await vehicleModelAppService.CreateVehicleModel(model, cancellation);

            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteModel([FromHeader] string apiKey, int id, CancellationToken cancellation) 
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");
            var result = await vehicleModelAppService.DeleteVehicleModel(id, cancellation);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateModel([FromHeader] string apiKey,[FromBody] VehicleModelDto modeldto, CancellationToken cancellation)
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var model = new VehicleModel();
            model.Name = modeldto.Name;
            model.Id = modeldto.Id; 

            var existingModel = await vehicleModelAppService.GetVehicleModel(model.Id, cancellation);
            if (existingModel == null)
            {
                return NotFound();
            }

            existingModel.Name = model.Name;

            var result = await vehicleModelAppService.UpdateVehicleModel(existingModel, cancellation);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
