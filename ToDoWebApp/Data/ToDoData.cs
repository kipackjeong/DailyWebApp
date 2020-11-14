using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApp.Model;

namespace ToDoWebApp.Data
{
    public class ToDoData : IToDoData
    {
        private ISQLAccess _data;

        #region Contructor

        public ToDoData(ISQLAccess data)
        {
            _data = data;
        }

        #endregion Contructor

        #region Methods

        public Task<List<ToDoItem>> GetTodayToDoItem()
        {
            var today = DateTime.Now.ToString("MM/dd/yy");
            // need sql query
            var sql = @$" select * from dbo.ToDoList
                           where DateCreated = '{today}'";

            // Insert sql query in to SQLAccess: LoadData Method
            return _data.LoadData<ToDoItem, dynamic>(sql, new { }); // empty object
        }

        public Task<List<ToDoItem>> GetOverallItem()
        {
            var sql = "select * from dbo.ToDoList";
            return _data.LoadData<ToDoItem, dynamic>(sql, new { });
        }

        public async Task InsertItem(ToDoItem item)
        {
            var done = (int)item.Done;
            var sql = @$"Insert into dbo.ToDoList (Title, DateTimeCreated, DateCreated, Done)
                                         values (@Title, @DateTimeCreated, @DateCreated, {done})";
            await _data.UpdateData<ToDoItem>(sql, item);
        }

        public async Task DeleteItem(ToDoItem item)
        {
            var sql = $"delete from dbo.ToDoList where Title = @Title";
            await _data.UpdateData<ToDoItem>(sql, item);
        }

        public async Task UpdateToDoneStatus(ToDoItem item)
        {
            var sql = $@"update dbo.ToDoList Set Done = 1 where Title = @Title";
            await _data.UpdateData<ToDoItem>(sql, item);
        }

        public async Task UpdateToUnDoneStatus(ToDoItem item)
        {
            var sql = $@"update dbo.ToDoList Set Done = 0 where Title = @Title";
            await _data.UpdateData<ToDoItem>(sql, item);
        }

        #endregion Methods
    }
}