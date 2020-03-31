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
            var color = _mapper.Map<Database.Entities.CarColor>(carModel.Color);
            var type = _mapper.Map<Database.Entities.CarType>(carModel.Type);
            var make = _mapper.Map<Database.Entities.CarMake>(carModel.Make);

            newCar.Make = _context.CarMakes.Find(carModel.Make.Id);
            newCar.Type = _context.CarTypes.Find(carModel.Type.Id);
            newCar.Color = _context.CarColors.Find(carModel.Color.Id); 

            _context.Cars.Add(newCar);
            _context.SaveChanges();
            return _mapper.Map<CarModel>(newCar);
        }

        public void DeleteCar(CarModel carModel)
        {
            if (_context.Cars.All(x => x.Id != carModel.Id))
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
