using Newtonsoft.Json;
using SQLClass;
using SQLLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobFinder_websmithAdmin.Controllers
{
    public class EmployeeMasterController : Controller
    {
        // GET: EmployeeMaster
        public ActionResult Index()
        {
            object lstCountry = new CountryMasterLogic().CountryMaster_Get_GetAll();
            ViewBag.lstCountry = JsonConvert.DeserializeObject<List<CountryStateClass>>(lstCountry.ToString());

            object lstState = new StateMasterLogic().StateMaster_Get_GetAll();
            ViewBag.lstState = JsonConvert.DeserializeObject<List<StateCityClass>>(lstState.ToString());

            object lstCity = new CityMasterLogic().CityMaster_Get_GetAll();
            ViewBag.lstCity = JsonConvert.DeserializeObject<List<CityEmployeeClass>>(lstCity.ToString());

            object lstJobExperience = new JobExperienceLogic().JobExperience_Get_GetAll();
            ViewBag.lstJobExperience = JsonConvert.DeserializeObject<List<JobExperienceEmployeeClass>>(lstJobExperience.ToString());

            return View();
        }
    }
}