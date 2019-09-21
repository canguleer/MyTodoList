using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList_Application.Models
{
    public class Helpers : I_Todo
    {
        private Context _db;
        public Helpers(Context db)
        {
            _db =db;
        }

        public List<V_Todo> GetList()
        {
            List<V_Todo> data = _db.ToDo.ToList();
            return data;
        }

        public int SaveData(V_Todo data)
        {
            _db.ToDo.Add(data);
            int result = _db.SaveChanges();
            HttpContext.Current.Session["liste"] = null;
            return result;
        }

        public V_Todo GetData(int id)
        {
            var findData = _db.ToDo.Where(w => w.Id ==id).FirstOrDefault();
            return findData;
        }

        public int UpdateData(V_Todo data)
        {
            var findData = _db.ToDo.Where(w => w.Id == data.Id).FirstOrDefault();
            findData.Title = data.Title;
            findData.Description = data.Description;
            findData.IsDone = data.IsDone;
            findData.status = data.status;
            findData.Date = data.Date;
            findData.Time = data.Time;
            int result = _db.SaveChanges();
            HttpContext.Current.Session["liste"] = null;
            return result;
        }

        public int DeleteData(int id)
        {
            var findData = _db.ToDo.Where(w => w.Id == id).FirstOrDefault();
            if (findData == null)
            {
                return 0;
            }
            _db.ToDo.Remove(findData);
            int result = _db.SaveChanges();
            return result;
        }

        public string TimeAlert()
        {
            string result = string.Empty;
            DateTime date = DateTime.Now.Date;
            TimeSpan time = DateTime.Now.TimeOfDay;
            List<V_Todo> liste = null;
            
            if (HttpContext.Current.Session["liste"] == null)
            {
                liste = _db.ToDo.Where(t => t.Date == date && !t.IsDone).ToList();
                HttpContext.Current.Session["liste"] = liste;
            }
            var liste2 = (List<V_Todo>)HttpContext.Current.Session["liste"];
            var data = liste2.Where(r => r.Time.Hours == time.Hours && r.Time.Minutes == time.Minutes).FirstOrDefault();

            if (data != null)
            {
                data.IsDone = true;
                _db.SaveChanges();
                HttpContext.Current.Session["liste"] = null;
                result = data.Title + " başlıklı hatırlatmanın zamanı gelmiştir";
            }
            return result;
        }
    }
}