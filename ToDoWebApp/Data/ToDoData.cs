using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Model;

namespace ToDoWebApp.Data
{
    public class ToDoData
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
        public async Task<List<ToDoItem>> GetOverallItem()
        {
            return;
        }
        public async Task InsertItem(ToDoItem item)
        {

        }
        public async Task DeleteItem(ToDoItem item)
        {
            
        }
        


        
        #endregion
    }
}
