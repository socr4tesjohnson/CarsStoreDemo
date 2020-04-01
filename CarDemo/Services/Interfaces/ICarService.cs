using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarModel> LoadAllCars();
        Task<CarModel> LoadCarAsync(int carId);
        CarModel AddCar(CarModel carModel);
        void DeleteCar(CarModel carModel);
        CarModel UpdateCar(CarModel carModel);
        IEnumerable<CarColorModel> LoadCarColors();
        IEnumerable<CarTypeModel> LoadCarTypes();
        IEnumerable<CarMakeModel> LoadCarMake();
    }
}
