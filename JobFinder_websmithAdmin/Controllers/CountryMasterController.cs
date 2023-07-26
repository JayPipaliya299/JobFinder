using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
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
    public class CountryMasterController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Save Data
        [HttpPost]
        public ActionResult CountryMaster_Insert_Update(CountryMasterClass oClass)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
               if(string.IsNullOrEmpty(oClass.CountryName))
               {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter country name";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
               }

                oClass.CreatedBy = Guid.Parse(User.Identity.GetUserId());
                mRes = new CountryMasterLogic().CountryMaster_Insert_Update(oClass);
            }
            catch (Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }

            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Save Data

        #region Get Data
        [HttpPost]
        public JsonResult CountryMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            try
            {
                object obj = new CountryMasterLogic().CountryMaster_Get_GetAllPagging(RowsPerPage, PageNumber);

                return Json(obj.ToString(), JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Get Data

        #region Get Data By ID
        public JsonResult CountryMaster_Get_GetByID(int CountryIDP)
        {
            object data = new CountryMasterLogic().CountryMaster_Get_GetByID(CountryIDP);
            return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion Get Data By ID

        #region Delete Data By ID
        [HttpPost]
        public JsonResult CountryMaster_GeneralAction(int CountryIDP, int ActionType)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                Guid UserIDF = Guid.Parse(User.Identity.GetUserId());
                mRes = new CountryMasterLogic().CountryMaster_GeneralAction(CountryIDP, ActionType, UserIDF);
                
            }
            catch (Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes,JsonRequestBehavior.AllowGet);
        }
        #endregion Delete Data By ID
    }
}