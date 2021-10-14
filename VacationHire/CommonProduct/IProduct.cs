using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProduct
{
    public interface IProduct
    {
        string GetProductType();
        bool GetAvailability();
        bool GetDamage();
        float GetPrice();
    }

    public enum ProductType
    {
        Car,
        Bike,
        House
    }
}
