using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDto()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join c2 in context.Colors
                             on c.ColorId equals c2.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = c2.Name,
                                 DailyPrice = c.DailyPrice,
                             };
                return result.ToList();

            }
        }
    }
}