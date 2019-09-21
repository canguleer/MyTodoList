using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList_Application.Models;



namespace ToDoList_Application.Controllers
{

    public class HomeController : Controller
    {
        I_Todo _todo;
        public HomeController(I_Todo todo)
        {
            _todo = todo;
        }
        public ActionResult Index(int? page)
        {

            var data = _todo.GetList().Where(x => x.status == true).ToList().ToPagedList(page ?? 1, 6);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCreateData(V_Todo data)
        {
            int sonuc = _todo.SaveData(data);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Create", data);
        }


        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var data = _todo.GetData(id.Value);
            return View(data);
        }

        [HttpPost]
        public ActionResult SaveUpdateData(V_Todo data)
        {
            int sonuc = _todo.UpdateData(data);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Update", data);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var data = _todo.GetData(id.Value);
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteData(V_Todo data)
        {
            int sonuc = _todo.DeleteData(data.Id);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Delete", "Home");
        }

        public JsonResult GetAlert()
        {
            var result = _todo.TimeAlert();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}