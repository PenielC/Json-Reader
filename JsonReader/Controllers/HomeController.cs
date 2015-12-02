using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonReader.Controllers
{
    public class HomeController : Controller
    {
        //display view
        public ActionResult Index()
        {
            
            return View();
        }

        //call for finding file and returning json objects
        public ActionResult GetJobs()
        {
            string filePath = Server.MapPath(@"~/Content\jobs.json");
            //read file
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                //deserialize to json object
                dynamic jobsObject = JsonConvert.DeserializeObject(json);
                //file has a header [jobs] with entries.  Get only the entries from the file and not header
                dynamic array = jobsObject.jobs;
                //convert array of entries to list of anonymous type to serialize into json object
                var items = ((JArray)array).Select(x => new 
                {
                    Client = (string)x["client"],
                    JobNumber = (string)x["job-number"],
                    JobName = (string)x["job-name"],
                    Due = (DateTime)x["due"],
                    Status = (string)x["status"]
                }).ToList();
                //return json objects
                return Json(items   , JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}