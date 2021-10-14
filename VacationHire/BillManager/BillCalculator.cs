using AutoVehicles;
using CurrecyExchange;
using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    public class BillCalculator : IBill
    {
        public float CalculateBill<T>(T data, OrderData orderData)
        {
            float combinedPrice = 0;
            //if type is Car => do something
            //if type is bike => do something else
            if (data is IAutoVehicle)
            {
                combinedPrice = autovehiclePrice(data, orderData);
            }

            return combinedPrice;
        }

        private float autovehiclePrice<T>(T data, OrderData orderData)
        {
            float combinedPrice;
            IAutoVehicle vehicle = data as IAutoVehicle;
            combinedPrice = vehicle.GetPrice();
            float rentPrice = combinedPrice;

            if (vehicle.GetDamage())
            {
                combinedPrice = combinedPrice + combinedPrice * (float)0.1;
            }
            double days = penaltyDays(orderData);
            if (days > 0)
            {
                combinedPrice += (float)(days / 100) * rentPrice;
            }
            int usedFuel = vehicle.GetUsedFuel();
            if (usedFuel > 0)
            {
                combinedPrice = combinedPrice + usedFuel * 5;
            }

            return combinedPrice;
        }

        private double penaltyDays(OrderData data)
        {
            //Was order returned in time

            DateTime startDate = DateTime.Parse(data.StartDate);

            double difference = (startDate.AddDays(data.Days) - startDate).TotalDays;

            return difference;
        }
    }
}
