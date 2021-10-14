using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderHandler
    {
        int AddOrder(OrderData data);
        int GetOrderDays(int id);
        OrderData GetOrder(int id);
        List<OrderData> GetOrders();
        void DeleteOrder(int id);
    }
}
