using AutoVehicles;
using CommonProduct;
using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.AutoVehicles
{
    class Minivan : IAutoVehicle
    {
        string mName;
        AutoVehicleType mType;
        int mDamage;
        int mFuel;
        int mAvailability;
        float mPrice;
        int mUsedFuel;

        public Minivan(CarData data)
        {
            mName = data.Name;
            Enum.TryParse(data.Type, out mType);
            mDamage = data.Damage;
            mFuel = data.Fuel;
            mAvailability = data.Availability;
            mPrice = data.Price;
            mUsedFuel = data.UsedFuel;
        }
        public string GetAutoVehicleType()
        {
            return mType.ToString();
        }

        public bool GetAvailability()
        {
            if (mAvailability == 1)
                return true;
            return false;
        }

        public bool GetDamage()
        {
            if (mDamage == 1)
                return true;
            return false;
        }

        public int GetUsedFuel()
        {
            return mUsedFuel;
        }

        public string GetName()
        {
            return mName;
        }

        public float GetPrice()
        {
            return mPrice;
        }

        public string GetProductType()
        {
            return ProductType.Car.ToString();
        }
    }
}
