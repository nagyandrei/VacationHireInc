using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AutovehicleHandler : IAutoVehicleHandler
    {
        IDataAccess dataAccess;
        public AutovehicleHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public int SaveVehicle(CarData car)
        {
            string sql = string.Empty;

            sql = "insert into dbo.Autovehicle (Id, Name, Type, Damage, Fuel, Availability, Price) values (@Id, @Name, @Type, @Damage, @Fuel, @Availability, @Price)";

            return dataAccess.Save(sql, car);
        }

        public List<CarData> LoadVehicles()
        {
            string sql = "select Id, Name, Type, Damage, Fuel, Availability, Price from dbo.Autovehicle";
            return dataAccess.LoadData<CarData>(sql);
        }

        public int DeleteCar(int id)
        {
            string sql = "delete from dbo.Autovehicle where Id=@id";
            return dataAccess.Delete(sql);
        }

        public int UpdateVehicle(CarData car)
        {
            string sql = "update dbo.Autovehicle set Name=@Name, Type=@Type, Damage=@Damage, Fuel=@Fuel, Availability=@Availability, Price=@Price where Id=@Id";
            return dataAccess.Update(sql, car);
        }
    }
}
