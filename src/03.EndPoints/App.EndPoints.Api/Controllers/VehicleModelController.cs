using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController(IVehicleModelAppService vehicleModelAppService,
        IConfiguration configuration) : ControllerBase
    {
        [HttpGet("GetAll")] 
        public List<VehicleModel> GetAllModels([FromHeader] string apiKey)
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var models = vehicleModelAppService.GetAllVehicleModels();
            return models;
        }

        [HttpGet("GetById/{id}")]
        public VehicleModel GetVehicleModelById([FromHeader] string apiKey, int id) 
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var model = vehicleModelAppService.GetVehicleModel(id);
            return model;
        }
        [HttpPost("Create")]
        public IActionResult CreateModel([FromHeader] string apiKey,[FromBody] VehicleModelDto vehicleModelDto)
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var model = new VehicleModel();
            model.Name = vehicleModelDto.Name;

            var result = vehicleModelAppService.CreateVehicleModel(model);

            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteModel([FromHeader] string apiKey, int id) 
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");
            var result = vehicleModelAppService.DeleteVehicleModel(id);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public IActionResult UpdateModel([FromHeader] string apiKey,[FromBody] VehicleModelDto modeldto)
        {
            if (apiKey != configuration["AppSettings:ApiKey"])
                throw new UnauthorizedAccessException("ای پی ای وارد شده معتبر نمی باشد");

            var model = new VehicleModel();
            model.Name = modeldto.Name;
            model.Id = modeldto.Id; 

            var existingModel = vehicleModelAppService.GetVehicleModel(model.Id);
            if (existingModel == null)
            {
                return NotFound();
            }

            existingModel.Name = model.Name;

            var result = vehicleModelAppService.UpdateVehicleModel(existingModel);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
