using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerksDemo.Models;
using Web.Models;
using Web.Services;
using Web.Services.Interfaces;

namespace PerksDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carservice)
        {
            _carService = carservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IEnumerable<CarModel> LoadCars()
        {
            return _carService.LoadAllCars();
        }


        public IEnumerable<CarColorModel> LoadCarColors()
        {
            return _carService.LoadCarColors();
        }
        public IEnumerable<CarTypeModel> LoadCarTypes()
        {
            return _carService.LoadCarTypes();
        }
        public IEnumerable<CarMakeModel> LoadCarMakes()
        {
            return _carService.LoadCarMake();
        }


        [HttpPost]
        public async Task<CarModel> LoadCarAsync(int carId)
        {
            return await _carService.LoadCarAsync(carId);
        }

        [HttpPost]
        public CarModel AddCar([FromBody] CarModel carModel)
        {
            return _carService.AddCar(carModel);
        }

        [HttpPost]
        public CarModel UpdateCar([FromBody] CarModel carModel)
        {
            return _carService.EditCar(carModel);
        }

        [HttpPost]
        public void DeleteCar([FromBody] CarModel carModel)
        {
            _carService.DeleteCar(carModel);
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
