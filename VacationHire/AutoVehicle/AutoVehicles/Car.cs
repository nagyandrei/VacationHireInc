using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVehicles
{
    public abstract class Car: IAutoVehicle
    {
        public virtual string GetAutoVehicleType()
        {
            throw new NotImplementedException();
        }

        public virtual  bool GetAvailability()
        {
            throw new NotImplementedException();
        }

        //public virtual int GetCargo()
        //{
        //    throw new NotImplementedException();
        //}

        public virtual bool GetDamage()
        {
            throw new NotImplementedException();
        }

        public virtual int GetUsedFuel()
        {
            throw new NotImplementedException();
        }

        public virtual string GetName()
        {
            throw new NotImplementedException();
        }

        public virtual float GetPrice()
        {
            throw new NotImplementedException();
        }

        public virtual string GetProductType()
        {
            throw new NotImplementedException();
        }
    }

    public enum AutoVehicleType
    {
        Sedan,
        Minivan,
        Truck
    }
}
