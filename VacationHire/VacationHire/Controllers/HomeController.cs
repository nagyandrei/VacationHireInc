using AutoVehicle.AutoVehicles;
using AutoVehicles;
using BillManager;
using CommonProduct;
using CurrecyExchange;
using DataManager;
using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VacationHire.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CarManager()
        {
            ViewBag.Message = "Add some cars";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarManager(CarData data)
        {
            ViewBag.Message = "Add some cars";

            if (ModelState.IsValid)
            {
                
                try
                {
                    AutoVehicleManager.Instance().AddCar(data);
                    return RedirectToAction("CarList");
                }
                catch
                {

                }
            }
            return View();
        }

        public ActionResult CarList()
        {
            ViewBag.Message = "Rent a car";

            var result = AutoVehicleManager.Instance().LoadCars();

            return View(result);
        }

        public ActionResult OrderManager()
        {
            ViewBag.Message = "Rent some products";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderManager(OrderData data, string message)
        {
            ViewBag.Message = "Rent some products";
            if (ModelState.IsValid)
            {
                data.StartDate = DateTime.Now.ToString();
                try
                {
                    data.ProductId = int.Parse(message);
                    OrdersManager.Instance().TakeNewOrder(data);
                    return RedirectToAction("OrderList");
                }
                catch
                {
                    //doSomething
                }
            }

            return View();
        }


        public ActionResult OrderList(FormCollection form)
        {
            ViewBag.Message = "Rent some products";
            
            if (form.Count > 0)
            {
                string carDamage = form["CarDamage"].ToString();
                string fuel = form["CarFuel"].ToString();
                int id = int.Parse(form["id"].ToString());
                return RedirectToAction("ReturnOrder", new
                {
                    id,
                    carDamage,
                    fuel,
                });
            }
            List<OrderData> result = new List<OrderData>();
            try
            {
                result = OrdersManager.Instance().GetOrders();
            }
            catch
            {
                //doSomething
            }

            return View(result);
        }

        public ActionResult Rent(int id, string value)
        {
            ViewBag.Message = "Rent some products";

            try
            {
                AutoVehicleManager.Instance().RentCar(id);
            }
            catch
            {
                //doSomething
            }
            ViewBag.Message = id;
            return RedirectToAction("OrderManager", new { message = id.ToString() });
        }


                                   //carDamage and fuel should be part of Order as args[]
        public ActionResult ReturnOrder(int id, string carDamage, string fuel)
        {
            ViewBag.Message = "Return product";
            float finalPrice = 0;
            try
            {

                var order = OrdersManager.Instance().GetOrderById(id);

                IProduct product = createProductFromOrder(order);
                finalPrice = OrdersManager.Instance().GetFinalPrice(product, order);

                OrdersManager.Instance().DeleteOrder(id);
            }
            catch
            {
                //doSomething
            }
            ViewBag.Message = finalPrice;

            return View();
        }

        [HttpPost]
        public ActionResult ReturnOrder(FormCollection form)
        {
            try
            {
                string currecy = form["Currency"].ToString();
                double priceInRon = double.Parse(form["FinalPrice"].ToString());

                ExchangeCalculator calc = new ExchangeCalculator();

                ViewBag.Message = calc.GetConvertedPrice(currecy, priceInRon) + " " + currecy;
            }
            catch
            {
                //doSomething
            }
            finally
            {

            }

            return View("Bill");
        }

        private static IProduct createProductFromOrder(OrderData order)
        {
            IProduct product = null;
            if (order.Type.Equals(ProductType.Car.ToString()))
            {
                //order.getOptionalArgs()
                
                var carData = AutoVehicleManager.Instance().GetCar(order.ProductId);
                Random random = new Random();
                AutoVehicleManager.Instance().ReturnCar(order.ProductId, random.Next(30));
                product = AutoVehicleFactory.CreateAutoVehicle(carData);
            }

            return product;
        }

    }
}
