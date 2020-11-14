using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Model
{
    public enum Done
    {
        NotDone,
        Done
    }
    public class ToDoItem
    {
        public string Title { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string DateCreated { get; set; }
        public bool done { get; set; } = false;
        public Done Done { get; set; }

        // ctor
        public ToDoItem()
        {

        }
        public ToDoItem(string title, DateTime dateTimeCreated)
        {
            Title = title;
            DateTimeCreated = dateTimeCreated;
            DateCreated = dateTimeCreated.ToString("MM/dd/yy"); // sql purpose
            Done = Done.NotDone;
        }
    }
}
