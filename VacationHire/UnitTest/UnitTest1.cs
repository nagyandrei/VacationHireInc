using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManager;
using AutoVehicle.AutoVehicles;
using CommonProduct;
using BillManager;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AutoVehicleFactory()
        {
            CarData data = new CarData
            {
                Availability = 1,
                Damage = 1,
                Fuel = 1,
                Id = 1,
                Name = "car",
                Price = 1,
                Type = "Sedan"
            };
            var result = AutoVehicleFactory.CreateAutoVehicle(data);

            var type = result.GetType();

            Assert.AreEqual(type.Name, "Sedan");

            Assert.AreEqual(result.GetDamage(), true);
            Assert.AreEqual(result.GetAvailability(), true);
            Assert.AreEqual(result.GetName(), "car");
        }

        [TestMethod]
        public void Test_AutoVehicle_SetRemainingFuelTank()
        {
            CarData data = new CarData
            {
                Availability = 1,
                Damage = 1,
                Fuel = 20,
                Id = 1,
                Name = "car",
                Price = 1,
                Type = "Sedan",
                UsedFuel = 0
            };
            AutoVehicleManager.Instance().SetRemainingFuelTank(data, 10);

            var result = data.UsedFuel;
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void Test_CalculateBill()
        {
            CarData carData = new CarData
            {
                Availability = 1,
                Damage = 1,
                Fuel = 20,
                Id = 1,
                Name = "car",
                Price = 100,
                Type = "Sedan",
                UsedFuel = 5
            };

            OrderData orderData = new OrderData
            {
                Days = 1,
                StartDate = DateTime.Now.ToString(),
                Type = "Car"
            };


            BillCalculator calc = new BillCalculator();

            var result = calc.CalculateBill(new Sedan(carData), orderData);

            Assert.AreEqual(result, 211);
        }
    }
}
