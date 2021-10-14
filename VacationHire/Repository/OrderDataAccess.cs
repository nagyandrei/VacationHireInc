using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDataAccess: IDataAccess
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = VacationHireDB; Integrated Security = True";

        public int Save<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Execute(sql, data);
                }
                catch (Exception ex)
                {
                    //handle save exception
                    return -1;
                }
            }
        }

        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Query<T>(sql).ToList();
                }
                catch (Exception ex)
                {
                    //handle load exception
                    return new List<T>();
                }
            }
        }

        public int Delete(string sql)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    return connection.Execute(sql);
                }
                catch (Exception ex)
                {
                    //handle delete exception
                    return -1;
                }
            }
        }

        public int Update<T>(string sql, T data)
        {
            throw new NotImplementedException();
        }
    }
}
