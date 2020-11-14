﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Model
{
    public class Date
    {
        public string DateCreated { get; set; }
        public IList<ToDoItem> DoneList { get; set; }
        public IList<ToDoItem> NotDoneList { get; set; }
        public bool DetailClicked { get; set; } = false;


        public Date(string dateCreated)
        {
            DateCreated = dateCreated;
            DoneList = new List<ToDoItem>();
            NotDoneList = new List<ToDoItem>();
        }
    }
}