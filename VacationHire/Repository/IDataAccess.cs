using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataAccess
    {
        int Save<T>(string sql, T data);
        List<T> LoadData<T>(string sql);
        int Delete(string sql);
        int Update<T>(string sql, T data);
    }
}
