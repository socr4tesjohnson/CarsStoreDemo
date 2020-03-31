using Microsoft.AspNetCore.SignalR;
using Services.Models;
using Services.Services;
using System.Threading.Tasks;

namespace Services.Hubs
{
    public class CarHub: Hub
    {
        private readonly CarService _carService;

        public CarHub(CarService carservice)
        {
            _carService = carservice;
        }
        public void LoadCars()
        {   
            Clients.All.SendAsync("LoadCars", _carService.LoadAllCars());
        }

        public void LoadCar(int carId)
        {
            Clients.All.SendAsync("LoadCars", _carService.LoadCarAsync(carId));
        }
        public void AddCar(CarModel carModel)
        {
            Clients.All.SendAsync("UpdateCars", _carService.AddCar(carModel));

        }
        public void UpdateCar(CarModel carModel)
        {
            Clients.All.SendAsync("UpdateCars", _carService.EditCar(carModel));
        }
        public void Delete(CarModel carModel)
        {
            _carService.DeleteCar(carModel);

            Clients.All.SendAsync("RemoveCars", carModel);
        }

        public Task Log(string user, string message) 
        {
            return Clients.All.SendAsync("ReveiveMessage", user, message);
        }
    }
}
