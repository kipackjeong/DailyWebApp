using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoWebApp.Data
{
    public interface ISQLAccess
    {
        Task<List<T>> LoadData<T>(string sql, T param);
        Task UpDateData<T>(string sql, T param);
    }
}