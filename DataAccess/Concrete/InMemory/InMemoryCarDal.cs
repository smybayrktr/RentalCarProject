using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id=1, BrandId=1, ColorId=1, DailyPrice=250, Description="Beyaz Araba", ModelYear=2015 },
                new Car { Id=2, BrandId=2, ColorId=2, DailyPrice=400, Description="Siyah Araba", ModelYear=2010 },
                new Car { Id=3, BrandId=2, ColorId=4, DailyPrice=1500, Description="Kırmızı Araba", ModelYear=2005 },
                new Car { Id=4, BrandId=3, ColorId=5, DailyPrice=130, Description="Gri Araba", ModelYear=2000 }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var result = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            var result = _cars.Find(c => c.Id == carId);
            return result;
            
        }

        public void Update(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.Id == car.Id);
            result.BrandId=car.BrandId;
            result.ColorId=car.ColorId;
            result.DailyPrice=car.DailyPrice;
            result.Description=car.Description;
            result.ModelYear=car.ModelYear;
        }
    }
}
