using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UberForInterviews.Models;

namespace UberForInterviews.Controllers
{
    public class HomeController : Controller
    {
        private UberForInterviewsDbEntities db = new UberForInterviewsDbEntities();

        public ActionResult Index()
        {
            return View();
        }


        //API calls shouldn't really be in controllers that server up views
        [HttpGet]
        [AllowAnonymous]
        public JsonResult getDriverStats()
        {
            var driverStats = new List<StatsModel>();
            try
            {
                var groupedStats = from d in db.Drivers group d by d.Status;

                //db to API mappings should be inside some kind of data provider
                foreach (var stat in groupedStats.ToList())
                {
                    driverStats.Add(new StatsModel(stat.Key, stat.Count()));
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                //If we can't connect to the DB use this sample object
                driverStats.Add(new StatsModel("pickingUp", 0));
            }
            
            return new JsonResult { Data = driverStats.ToList(), JsonRequestBehavior= JsonRequestBehavior.AllowGet};
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult getDriverLocations()
        {
            try
            {
                return new JsonResult { Data = db.Drivers.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            } catch (Exception e)
            {
                Console.WriteLine(e);
                var driverStats = new List<Object>();
                driverStats.Add(new { id = 1, Name = "liam", Status = "picking up", Latitude = 45.390830, Longitude = -75.722735 });
                return new JsonResult { Data = driverStats, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
        }
    }
}