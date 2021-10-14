using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoVehicles;
using DataManager;
using Repository;

namespace AutoVehicle.AutoVehicles
{
    public class AutoVehicleManager : IReturnCar
    {
        IAutoVehicleHandler mHandler;

        static AutoVehicleManager _instance = null;
        static readonly object obj = new object();
        private AutoVehicleManager()
        {
            mHandler = new AutovehicleHandler(new AutovehicleDataAccess());
        }

        public static AutoVehicleManager Instance()
        {
            lock (obj)
            {
                if (_instance == null)
                {
                    _instance = new AutoVehicleManager();
                }
                return _instance;
            }
        }

        public void ReturnCar(int id, int usedFuel)
        {
            var car = GetCar(id);
            SetAvailability(car, 0);
            SetDamageState(car);
            SetRemainingFuelTank(car, usedFuel);
        }

        public void RentCar(int id)
        {
            var car = GetCar(id);
            SetAvailability(car, 1);
        }

        public void SetAvailability(CarData data, int state)
        {
            data.Availability = state;
            mHandler.UpdateVehicle(data);
        }

        public void SetDamageState(CarData data)
        {
            data.Damage = new Random().Next(1);
            mHandler.UpdateVehicle(data);
        }

        public void SetRemainingFuelTank(CarData data, int usedFuel)
        {
            data.UsedFuel = data.Fuel - usedFuel;
        }

        public int AddCar(CarData data)
        {
            return mHandler.SaveVehicle(data);
        }

        public List<CarData> LoadCars()
        {
            return mHandler.LoadVehicles();
        }

        public CarData GetCar(int id)
        {
            return LoadCars().Find(_ => _.Id == id);
        }
    }
}
