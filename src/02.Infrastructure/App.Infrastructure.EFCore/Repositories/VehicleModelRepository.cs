using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;


namespace App.Infrastructure.EFCore.Repositories
{
    public class VehicleModelRepository(AppDbContext context) : IVehicleModelRepository
    {
        public Result CreateVehicleModel(VehicleModel vehicleModel)
        {
            context.Models.Add(vehicleModel);
            context.SaveChanges();
            if (context.SaveChanges() > 0)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت ثبت شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
        }

        public Result DeleteVehicleModel(int id)
        {
            var model = context.Models.FirstOrDefault(x => x.Id == id);
            if (model is null) return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            context.Models.Remove(model);
            context.SaveChanges();
            if (context.SaveChanges() > 0)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

        }
        public List<VehicleModel> GetAllVehicleModels()
        {
            return context.Models.ToList();
        }
        public VehicleModel GetVehicleModel(int id)
        {
            var model = context.Models.FirstOrDefault(model => model.Id == id);
            return model;
        }
        public Result UpdateVehicleModel(VehicleModel vehicleModel)
        {
            var existingModel = context.Models.FirstOrDefault(x => x.Id == vehicleModel.Id);
            if (existingModel is null) return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            existingModel.Id = vehicleModel.Id;
            existingModel.Name = vehicleModel.Name;

            context.SaveChanges();
            if (context.SaveChanges() > 0)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت بروزرسانی شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };

        }
    }
}
