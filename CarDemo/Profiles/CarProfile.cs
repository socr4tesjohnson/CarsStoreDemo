using AutoMapper;

namespace Web.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Models.CarModel, Database.Entities.Car>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Models.CarColorModel, Database.Entities.CarColor>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Models.CarTypeModel, Database.Entities.CarType>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Models.CarMakeModel, Database.Entities.CarMake>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
