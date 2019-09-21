using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ToDoList_Application.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=TodoConnectionString")
        {

        }                     
        public virtual DbSet<V_Todo> ToDo { get; set; }
    }
}