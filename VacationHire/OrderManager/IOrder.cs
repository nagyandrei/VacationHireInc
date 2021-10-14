using CommonProduct;
using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public interface IOrder
    {
        int TakeNewOrder(OrderData data);
        List<OrderData> GetOrders();
        float GetFinalPrice(IProduct product, OrderData data);
        OrderData GetOrderById(int id);
        void DeleteOrder(int id);
    }
}
