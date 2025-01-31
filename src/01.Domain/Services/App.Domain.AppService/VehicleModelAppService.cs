using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.AppService
{
    public class VehicleModelAppService(IVehicleModelService modelService) : IVehicleModelAppService
    {
        public async Task<Result> CreateVehicleModel(VehicleModel vehicleModel, CancellationToken cancellation)
        {
            var result = await modelService.Create(vehicleModel, cancellation);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت ثبت شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
        }

        public async Task<Result> DeleteVehicleModel(int id, CancellationToken cancellation)
        {
            var model = await modelService.GetById(id, cancellation);
            if (model is null) return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            var result = await modelService.Delete(id, cancellation);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

        }
        public async Task<List<VehicleModel>> GetAllVehicleModels(CancellationToken cancellation)
        {
            return await modelService.GetAll(cancellation);
        }
        public async Task<VehicleModel> GetVehicleModel(int id, CancellationToken cancellation)
        {
            var model = await modelService.GetById(id, cancellation);
            return model;
        }
        public async Task<Result> UpdateVehicleModel(VehicleModel vehicleModel, CancellationToken cancellation)
        {
            var existingModel = await modelService.GetById(vehicleModel.Id, cancellation);
            if (existingModel is null) return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            var result = await modelService.Update(vehicleModel, cancellation);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت بروزرسانی شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

        }
    }
}
