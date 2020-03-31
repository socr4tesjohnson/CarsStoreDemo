using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    interface ICarService
    {
        IEnumerable<CarModel> LoadAllCars();
        Task<CarModel> LoadCarAsync(int carId);
        CarModel AddCar(CarModel carModel);
        void DeleteCar(CarModel carModel);
        CarModel EditCar(CarModel carModel);
    }
}
