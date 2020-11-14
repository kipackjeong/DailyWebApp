using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion

        #region Methods
        public Task<List<ToDoItem>> GetTodayToDoItem()
        {
            // need sql query
            var sql = @$" select * from dbo.ToDoApp
                           where DateCreated = '{DateTime.Now.ToString("MM/dd/yyyy")}'";

            // Insert sql query in to SQLAccess: LoadData Method
            return _data.LoadData<ToDoItem, dynamic>(sql, new { }); // empty object
        }

        public Task<List<ToDoItem>> GetOverallItem()
        {
            var sql = "select * from dbo.ToDoApp";
            return _data.LoadData<ToDoItem, dynamic>(sql, new { });
        }

        public async Task InsertItem(ToDoItem item)
        {
            var sql = @"Insert into dbo.ToDoApp (Title, DateTimeCreated, DateCreated, Done)
                                         values (@Title, @DateTimeCreated, @DateCreated, @Done)";
            await _data.UpdateData<ToDoItem>(sql, item);
        }

        public async Task DeleteItem(ToDoItem item)
        {
            var sql = $"delete from dbo.ToDoApp where Title = @Title";
            await _data.UpdateData<ToDoItem>(sql, item);
        }

        #endregion
    }
}
