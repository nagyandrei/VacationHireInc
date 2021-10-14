using AutoVehicles;
using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVehicle.AutoVehicles
{
    public interface IReturnCar
    {
        void SetDamageState(CarData data);
        void SetRemainingFuelTank(CarData data, int usedFuel);
        void SetAvailability(CarData data, int state);
        void ReturnCar(int id, int usedFuel);
    }
}
