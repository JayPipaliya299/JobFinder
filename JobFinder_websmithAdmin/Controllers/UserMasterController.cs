using Microsoft.Ajax.Utilities;
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
    public class UserMasterController : Controller
    {
        // GET: UserMaster
        public ActionResult Index()
        {
            object lstRole = new RoleMasterLogic().RoleMaster_Get_GetAll();
            ViewBag.lstRole = JsonConvert.DeserializeObject<List<RoleMasterClass>>(lstRole.ToString());
            return View();
        }

        #region Get Data
        [HttpPost]
        public JsonResult UserMaster_Get_GetAllPagging(int RowsPerPage, int PageNumber)
        {
            try
            {
                object obj = new UserMasterLogic().UserMaster_Get_GetAllPagging(RowsPerPage, PageNumber);

                return Json(obj.ToString(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Get Data

        #region Get Data By ID
        public JsonResult UserMaster_Get_GetByID(string ID)
        {
            object data = new UserMasterLogic().UserMaster_Get_GetByID(ID);
            return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion Get Data By ID

        #region Save Data
        [HttpPost]
        public ActionResult UserRoleMaster_Insert(UserRoleMasterClass oClass)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                if (string.IsNullOrEmpty(oClass.RoleID))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please select a role";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }
                mRes = new UserRoleMasterLogic().UserRoleMaster_Insert(oClass);
            }
            catch(Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Save Data
    }
}