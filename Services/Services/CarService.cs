using AutoMapper;
using Database;
using Services.Models;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CarService : ICarService
    {
        private readonly CarsContext _context;
        private readonly IMapper _mapper;

        public CarService(CarsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CarModel AddCar(CarModel carModel)
        {
            if (_context.Cars.Any(x => x.Id == carModel.Id))
            {
                throw new Exception("A car already exists for this ID");
            }
            var newCar = _mapper.Map<Database.Entities.Car>(carModel);
            _context.Cars.Add(newCar);
            _context.SaveChanges();
            return _mapper.Map<CarModel>(newCar);
        }

        public void DeleteCar(CarModel carModel)
        {
            if (_context.Cars.Any(x => x.Id != carModel.Id))
            {
                throw new Exception("No Car found by that Id");
            }
            var selectedCar = _mapper.Map<Database.Entities.Car>(carModel);
            _context.Cars.Remove(selectedCar);
            _context.SaveChanges();
        }

        public CarModel EditCar(CarModel carModel)
        {
            if (_context.Cars.Any(x => x.Id != carModel.Id))
            {
                throw new Exception("No Car found by that Id");
            }
            var editedCar = _mapper.Map<Database.Entities.Car>(carModel);
            _context.SaveChanges();
            return _mapper.Map<CarModel>(editedCar);
        }

        public async Task<CarModel> LoadCarAsync(int carId)
        {
            return _mapper.Map<CarModel>(await _context.Cars.FindAsync(carId));
        }

        public IEnumerable<CarModel> LoadAllCars()
        {
            return _mapper.Map<IEnumerable<CarModel>>(_context.Cars.ToList());
        }
    }
}
