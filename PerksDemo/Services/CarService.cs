using AutoMapper;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Services.Interfaces;

namespace Web.Services
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
            var carEntity = _context.Cars.Find(carModel.Id);

            if (carEntity == null)
            {
                throw new Exception("No Car found by that Id");
            }
            _context.Cars.Remove(carEntity);
            _context.SaveChanges();
        }

        public CarModel UpdateCar(CarModel carModel)
        {
            var carEntity = _context.Cars.Find(carModel.Id);

            if (carEntity == null)
            {
                throw new Exception("No Car found by that Id");
            }

            _mapper.Map(carModel, carEntity);

            _context.SaveChanges();
            return _mapper.Map<Database.Entities.Car, CarModel>(carEntity);
        }

        public async Task<CarModel> LoadCarAsync(int carId)
        {
            return _mapper.Map<CarModel>(await _context.Cars.FindAsync(carId));
        }

        public IEnumerable<CarModel> LoadAllCars()
        {
            return _mapper.Map<IEnumerable<CarModel>>(_context.Cars.ToList());
        }

        public IEnumerable<CarColorModel> LoadCarColors()
        {
            return _mapper.Map<IEnumerable<CarColorModel>>(_context.CarColors.ToList());
        }

        public IEnumerable<CarTypeModel> LoadCarTypes()
        {
            return _mapper.Map<IEnumerable<CarTypeModel>>(_context.CarTypes.ToList());
        }

        public IEnumerable<CarMakeModel> LoadCarMake()
        {
            return _mapper.Map<IEnumerable<CarMakeModel>>(_context.CarMakes.ToList());
        }
    }
}
