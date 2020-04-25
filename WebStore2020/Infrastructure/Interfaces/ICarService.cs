using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarViewModel> GetAll();
        CarViewModel GetById(int id);
        void Commit();
        void AddNew(InitCarViewModel list, CarViewModel model);
        void Delete(int id);
    }
}
