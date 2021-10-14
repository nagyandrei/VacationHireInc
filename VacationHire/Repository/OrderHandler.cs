using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager;

namespace Repository
{
    public class OrderHandler : IOrderHandler
    {
        IDataAccess dataAccess;

        public OrderHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public int AddOrder(OrderData data)
        {
            string sql = string.Empty;

            sql = "insert into dbo.OrdersTable (Id, Name, Phone, Type, StartDate, Days, ProductId) values (@Id, @Name, @Phone, @Type, @StartDate, @Days, @ProductId)";
            return dataAccess.Save(sql, data);
        }

        public OrderData GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public int GetOrderDays(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderData> GetOrders()
        {
            string sql = "select Id, Name, Phone, Type, StartDate, Days, ProductId from dbo.OrdersTable";
            return dataAccess.LoadData<OrderData>(sql);
        }

        public void DeleteOrder(int id)
        {
            string sql = "delete from dbo.OrdersTable where Id=" + id.ToString();
            dataAccess.Delete(sql);
        }
    }
}
