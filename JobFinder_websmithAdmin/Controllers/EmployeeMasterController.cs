using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SQLClass;
using SQLHelper;
using SQLLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobFinder_websmithAdmin.Controllers
{
    [Authorize]
    public class EmployeeMasterController : Controller
    {
        // GET: EmployeeMaster
        public ActionResult Index()
        {
            object lstCountry = new CountryMasterLogic().CountryMaster_Get_GetAll();
            ViewBag.lstCountry = JsonConvert.DeserializeObject<List<CountryStateClass>>(lstCountry.ToString());

            object lstJobExperience = new JobExperienceLogic().JobExperience_Get_GetAll();
            ViewBag.lstJobExperience = JsonConvert.DeserializeObject<List<JobExperienceEmployeeClass>>(lstJobExperience.ToString());

            object lstSkill = new SkillMasterLogic().SkillMaster_Get_GetAll();
            ViewBag.lstSkill = JsonConvert.DeserializeObject<List<SkillEmployeeClass>>(lstSkill.ToString());
            
            return View();
        }

        [HttpPost]
        public JsonResult StateMaster_Get_GetStateByCountryIDP(int CountryIDP)
        {
            object lstState = new StateMasterLogic().StateMaster_Get_GetStateByCountryIDP(CountryIDP);
            List<StateMasterClass> lstStateModel = JsonConvert.DeserializeObject<List<StateMasterClass>>(lstState.ToString());
            ViewBag.lstState = lstStateModel;

            return Json(lstStateModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CityMaster_Get_GetCityByStateIDP(int StateIDP)
        {
            object lstCity = new CityMasterLogic().CityMaster_Get_GetCityByStateIDP(StateIDP);
            List<CityMasterClass> lstCityModel = JsonConvert.DeserializeObject<List<CityMasterClass>>(lstCity.ToString());
            ViewBag.lstCity = lstCityModel;

            return Json(lstCityModel, JsonRequestBehavior.AllowGet);
        }

        #region Get Data
        [HttpPost]
        public JsonResult EmployeeMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            try
            {
                object obj = new EmployeeMasterLogic().EmployeeMaster_Get_GetAllPagging(RowsPerPage, PageNumber);
                return Json(obj.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Get Data

        #region Save Data
        [HttpPost]
        public ActionResult EmployeeMaster_Insert_Update(EmployeeMasterClass oClass)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                if (oClass.CountryIDF == 0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a country";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (oClass.StateIDF == 0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a state";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (oClass.CityIDF == 0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a city";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(oClass.EmployeeName))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a employee name";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (oClass.EmployeeAge==0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a employee's age";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(oClass.EmployeeEmail))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a employee's email";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(oClass.EmployeeMobileNumber))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a employee's mobile number";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (oClass.EmployeeGender==0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a gender";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(oClass.EmployeeDomain))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a employee's domain";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (oClass.JobExperienceIDF == 0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a job experience";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(oClass.SkillIDF))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a skills";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                oClass.CreatedBy = Guid.Parse(User.Identity.GetUserId());
                mRes = new EmployeeMasterLogic().EmployeeMaster_Insert_Update(oClass);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Save Data

        #region Get Data By ID
        public JsonResult EmployeeMaster_Get_GetByID(int EmployeeIDP)
        {
            object data = new EmployeeMasterLogic().EmployeeMaster_Get_GetByID(EmployeeIDP);
            return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion Get Data By ID

        #region Delete Data By ID
        [HttpPost]
        public JsonResult EmployeeMaster_GeneralAction(int EmployeeIDP,int ActionType)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                Guid UserIDF = Guid.Parse(User.Identity.GetUserId());
                mRes = new EmployeeMasterLogic().EmployeeMaster_GeneralAction(EmployeeIDP,ActionType,UserIDF);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Delete Data By ID
    }
}