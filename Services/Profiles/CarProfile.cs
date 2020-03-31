using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class CarProfile: Profile
    {
        public CarProfile()
        {
            CreateMap<Database.Entities.Car, Models.CarModel>();
            CreateMap<Database.Entities.CarColor, Models.CarColorModel>();
            CreateMap<Database.Entities.CarMake, Models.CarMakeModel>();
            CreateMap<Database.Entities.CarType, Models.CarTypeModel>();
            
            CreateMap<Models.CarTypeModel, Database.Entities.CarType> ();
            CreateMap<Models.CarMakeModel, Database.Entities.CarMake> ();
            CreateMap<Models.CarColorModel, Database.Entities.CarColor> ();
            CreateMap<Models.CarModel, Database.Entities.Car> ();
        }
    }
}
