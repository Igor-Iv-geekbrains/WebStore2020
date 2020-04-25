using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Models;

namespace Webstore.Infrastructure.Interfaces
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
