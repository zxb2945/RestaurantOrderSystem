using CrazyElephant.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.Services
{
    public interface IDataServices
    {
        List<Dish> GetAllDishes();
    }
}
