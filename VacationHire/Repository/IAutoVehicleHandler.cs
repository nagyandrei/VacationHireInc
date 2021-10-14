using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAutoVehicleHandler
    {
        int SaveVehicle(CarData car);
        int UpdateVehicle(CarData car);
        List<CarData> LoadVehicles();
        int DeleteCar(int id);

    }
}
