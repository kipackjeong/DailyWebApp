using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApp.Model;

namespace ToDoWebApp.Data
{
    public interface IToDoData
    {
        Task DeleteItem(ToDoItem item);
        Task<Dictionary<string, Date>> GetItemsByDate();
        Task<List<ToDoItem>> GetOverallItem();

        Task<List<ToDoItem>> GetTodayToDoItem();

        Task InsertItem(ToDoItem item);

        Task UpdateToDoneStatus(ToDoItem item);

        Task UpdateToUnDoneStatus(ToDoItem item);
    }
}