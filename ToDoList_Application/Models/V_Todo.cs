using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList_Application.Models
{
    public class V_Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public bool status { get; set; }
    }
}