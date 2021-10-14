using CommonProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVehicles
{
    public interface IAutoVehicle : IProduct
    {
        string GetName();
        //int GetCargo();
        int GetUsedFuel();
        string GetAutoVehicleType();

    }
}
