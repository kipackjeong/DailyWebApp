using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Model
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string DateCreated { get; set; }
        public int Done { get; set; }
        public bool DoneBool
        {
            get => DoneBool;
            set
            {
                DoneBool = value;
                if (DoneBool)
                {
                    Done = 1;
                }
                else
                {
                    Done = 0;
                }
            }
        }
        
        // ctor
        public ToDoItem(string title, DateTime dateTimeCreated)
        {
            Title = title;
            DateTimeCreated = dateTimeCreated;
            DateCreated = dateTimeCreated.ToString("MM/dd/yy"); // sql purpose
            DoneBool = false;
        }
    }
}
