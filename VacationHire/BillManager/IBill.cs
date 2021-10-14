using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    public interface IBill
    {
        float CalculateBill<T>(T data, OrderData orderData);
    }
}
