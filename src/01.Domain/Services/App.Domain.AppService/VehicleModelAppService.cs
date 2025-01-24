using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;

namespace App.Domain.AppService
{
    public class VehicleModelAppService(IVehicleModelService modelService) : IVehicleModelAppService
    {
        public Result CreateVehicleModel(VehicleModel vehicleModel)
        {
            var result = modelService.Create(vehicleModel);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت ثبت شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
        }

        public Result DeleteVehicleModel(int id)
        {
            var model = modelService.GetById(id);
            if (model is null) return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            var result = modelService.Delete(id);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

        }
        public List<VehicleModel> GetAllVehicleModels()
        {
            return modelService.GetAll();
        }
        public VehicleModel GetVehicleModel(int id)
        {
            var model = modelService.GetById(id);
            return model;
        }
        public Result UpdateVehicleModel(VehicleModel vehicleModel)
        {
            var existingModel = modelService.GetById(vehicleModel.Id);
                if (existingModel is null) return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            var result = modelService.Update(vehicleModel);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت بروزرسانی شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

        }
    }
}
