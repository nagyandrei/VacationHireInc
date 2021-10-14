using BillManager;
using CommonProduct;
using DataManager;
using Order;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public sealed class OrdersManager : IOrder
    {
        IOrderHandler mHandler;
        private static OrdersManager _instace = null;
        static readonly object obj = new object();
        private OrdersManager()
        {
            mHandler = new OrderHandler(new DataAccess());
        }

        public static OrdersManager Instance()
        {
            lock (obj)
            {
                if (_instace == null)
                {
                    _instace = new OrdersManager();
                }
                return _instace;
            }
        }
        public int TakeNewOrder(OrderData data)
        {
          return  mHandler.AddOrder(data);
        }

        public List<OrderData> GetOrders()
        {
            return mHandler.GetOrders();
        }

        public float GetFinalPrice(IProduct product, OrderData data)
        {
            BillCalculator calc = new BillCalculator();
            return calc.CalculateBill<IProduct>(product, data);
        }

        public OrderData GetOrderById(int id)
        {
            return GetOrders().First(_ => _.Id == id);
        }

        public void DeleteOrder(int id)
        {
            mHandler.DeleteOrder(id);
        }
    }
}
