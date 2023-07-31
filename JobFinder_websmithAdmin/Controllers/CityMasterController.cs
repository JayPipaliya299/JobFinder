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
    [Authorize(Roles = "Admin")]
    public class CityMasterController : Controller
    {
        // GET: CityMaster
        public ActionResult Index()
        {
            object lstState = new StateMasterLogic().StateMaster_Get_GetAll();
            ViewBag.lstState = JsonConvert.DeserializeObject<List<StateCityClass>>(lstState.ToString());
            return View();
        }

        #region Get Data
        [HttpPost]
        public JsonResult CityMaster_Get_GetAllPagging(int RowsPerPage, int PageNumber)
        {
            try
            {
                object obj = new CityMasterLogic().CityMaster_Get_GetAllPagging(RowsPerPage, PageNumber);
                return Json(obj.ToString(),JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("Error :"+ex.Message,JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Get Data

        #region Save Data
        public ActionResult CityMaster_Insert_Update(CityMasterClass oClass)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                if(oClass.StateIDF == 0)
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a state";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }

                if(string.IsNullOrEmpty(oClass.CityName))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter a city name";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }
                oClass.CreatedBy = Guid.Parse(User.Identity.GetUserId());
                mRes = new CityMasterLogic().CityMaster_Insert_Update(oClass);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Save Data

        #region Get Data By ID
        public JsonResult CityMaster_Get_GetByID(int CityIDP)
        {
            object data = new CityMasterLogic().CityMaster_Get_GetByID(CityIDP);
            return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion Get Data By ID

        #region Delete Data By ID
        [HttpPost]
        public JsonResult CityMaster_GeneralAction(int CityIDP, int ActionType)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                Guid UserIDF = Guid.Parse(User.Identity.GetUserId());
                mRes = new CityMasterLogic().CityMaster_GeneralAction(CityIDP, ActionType, UserIDF);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Delte Data By ID
    }
}