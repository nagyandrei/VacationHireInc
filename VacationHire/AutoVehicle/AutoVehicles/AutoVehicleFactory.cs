using AutoVehicles;
using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.AutoVehicles;

namespace AutoVehicle.AutoVehicles
{
    static public class AutoVehicleFactory
    {
        static List<IAutoVehicle> instances = new List<IAutoVehicle>();
        static public IAutoVehicle CreateAutoVehicle(CarData data)
        {
            AutoVehicleType type;
            Enum.TryParse<AutoVehicleType>(data.Type, out type);

            switch (type)
            {
                case AutoVehicleType.Minivan:
                    Minivan minivan = new Minivan(data);
                    return minivan;
                    //instances.Add(minivan);
                case AutoVehicleType.Sedan:
                    Sedan sedan = new Sedan(data);
                    //instances.Add(sedan);
                    return sedan;
                case AutoVehicleType.Truck:
                    Truck truck = new Truck(data);
                    //instances.Add(truck);
                    return truck;
                default:
                    throw new InvalidOperationException();
            }
           
        }

        static List<IAutoVehicle> GetInstances()
        {
            return instances;
        }
    }
}
