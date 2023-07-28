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
    [Authorize(Roles = "Admin")]
    public class SkillMasterController : Controller
    {
        // GET: SkillMaster
        public ActionResult Index()
        {
            return View();
        }

        #region Get Data
        [HttpPost]
        public JsonResult SkillMaster_Get_GetAllPagging(int RowsPerPage, int PageNumber)
        {
            try
            {
                object obj = new SkillMasterLogic().SkillMaster_Get_GetAllPagging(RowsPerPage, PageNumber);
                return Json(obj.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Get Data

        #region Get Data By ID
        public JsonResult SkillMaster_Get_GetByID(int SkillIDP)
        {
            object data = new SkillMasterLogic().SkillMaster_Get_GetByID(SkillIDP);
            return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion Get Data By ID

        #region Save Data
        [HttpPost]
        public ActionResult SkillMaster_Insert_Update(SkillMasterClass oClass)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                if (string.IsNullOrEmpty(oClass.SkillName))
                {
                    mRes.Outval = 0;
                    mRes.Outmsg = "Please enter skill name";
                    return Json(mRes, JsonRequestBehavior.AllowGet);
                }
                oClass.CreatedBy = Guid.Parse(User.Identity.GetUserId());
                mRes = new SkillMasterLogic().SkillMaster_Insert_Update(oClass);
            }
            catch (Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Save Data

        #region Delete Data By ID
        [HttpPost]
        public JsonResult SkillMaster_GeneralAction(int SkillIDP, int ActionType)
        {
            MEMBERS.SQLReturnMessageNValue mRes;
            try
            {
                Guid UserIDF = Guid.Parse(User.Identity.GetUserId());
                mRes = new SkillMasterLogic().SkillMaster_GeneralAction(SkillIDP, ActionType, UserIDF);
            }
            catch (Exception ex)
            {
                mRes.Outval = "Error :" + ex.Message;
            }
            return Json(mRes, JsonRequestBehavior.AllowGet);
        }
        #endregion Delete Data By ID
    }
}