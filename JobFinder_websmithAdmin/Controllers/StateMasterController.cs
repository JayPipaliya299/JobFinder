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
    public class StateMasterController : Controller
    {
        // GET: StateMaster
        public ActionResult Index()
        {

            object lstCountry = new CountryMasterLogic().CountryMaster_Get_GetAll();
            ViewBag.lstCountry = JsonConvert.DeserializeObject<List<CountryStateClass>>(lstCountry.ToString());
            return View();
        }

        #region Get Data
        [HttpPost]
        public JsonResult StateMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            try
            {
                object obj = new StateMasterLogic().StateMaster_Get_GetAllPagging(RowsPerPage, PageNumber);
                return Json(obj.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("Error : "+ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Get Data

        #region Get Data By ID
        public JsonResult StateMaster_Get_GetByID(int StateIDP)
        {
            object data = new StateMasterLogic().StateMaster_Get_GetByID(StateIDP);
            return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion Get Data By ID

        #region Save Data
        [HttpPost]
        public ActionResult StateMaster_Insert_Update(StateMasterClass oClass)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                if(oClass.CountryIDF == 0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a country";
                    return Json(mRes,JsonRequestBehavior.AllowGet);
                }

                if(string.IsNullOrEmpty(oClass.StateName))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a state name";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                oClass.CreatedBy = Guid.Parse(User.Identity.GetUserId());
                mRes = new StateMasterLogic().StateMaster_Insert_Update(oClass);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error: " + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Save Data

        #region Delete Data By ID
        [HttpPost]
        public JsonResult StateMaster_GeneralAction(int StateIDP, int ActionType)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                Guid UserIDF = Guid.Parse(User.Identity.GetUserId());
                mRes = new StateMasterLogic().StateMaster_GeneralAction(StateIDP, ActionType,UserIDF);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error: " + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Delete Data By ID
    }
}