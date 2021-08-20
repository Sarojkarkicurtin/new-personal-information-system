using Google.Apis.Sheets.v4.Data;
using personal_inforamtion_system_new.DB;
using personal_inforamtion_system_new.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personal_inforamtion_system_new.Controllers
{
    public class HomeController : Controller
    {
        DbConn conn = new DbConn();
        //private object conn;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult GetJsonData(PersonalInfo data)
        {
            string message;
            conn.SaveData(data, out message);
            return Json(new JsonResult { Data = message });
            //return Json(data);

        }
        [HttpPost]
        public ActionResult GetAllJsonupdateData(PersonalInfo data)
        {
            string message;
            conn.SaveallupdtaeData(data, out message);
            return Json(new JsonResult { Data = message });
            //return Json(data);

        }

        [HttpPost]
        public ActionResult GetJsonDetail()
        {
            List<detail> PersonalList = conn.GetData();
            return Json(new JsonResult { Data = PersonalList, JsonRequestBehavior = JsonRequestBehavior.DenyGet });
        }
        [HttpPost]
        public ActionResult GetDeletedata(int? id)

        {
            string message;
            conn.Deletedata(id, out message);
            return Json(new JsonResult { Data = message });
            //return Json(data);

        }
        [HttpPost]
        
        public ActionResult FetchDetails(int? id)
        {
            PersonalInfo AllDataList = conn.Editmydata(id);
            return Json(new JsonResult { Data = AllDataList, JsonRequestBehavior = JsonRequestBehavior.DenyGet });
        }
    }
}
