﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApp.Model;

namespace ToDoWebApp.Data
{
    public interface IToDoData
    {
        Task DeleteItem(ToDoItem item);
        Task<List<ToDoItem>> GetOverallItem();
        Task<List<ToDoItem>> GetTodayToDoItem();
        Task InsertItem(ToDoItem item);
        void UpdateToDoneStatus(ToDoItem item);
        void UpdateToUnDoneStatus(ToDoItem item);
    }
}