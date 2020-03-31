using AutoMapper;

namespace Web.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Database.Entities.Car, Models.CarModel>();
            CreateMap<Database.Entities.CarColor, Models.CarColorModel>();
            CreateMap<Database.Entities.CarMake, Models.CarMakeModel>();
            CreateMap<Database.Entities.CarType, Models.CarTypeModel>();

            CreateMap<Models.CarModel, Database.Entities.Car>();
            CreateMap<Models.CarColorModel, Database.Entities.CarColor>();
            CreateMap<Models.CarTypeModel, Database.Entities.CarType>();
            CreateMap<Models.CarMakeModel, Database.Entities.CarMake>();
        }
    }
}
