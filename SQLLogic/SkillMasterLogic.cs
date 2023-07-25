using SQLClass;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class SkillMasterLogic
    {
        public object SkillMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            return new SqlHelper().GetJsonObject("SkillMaster_Get_GetAllPagging",new object[,]
            {
                {"RowsPerPage",RowsPerPage },
                {"PageNumber",PageNumber }
            });
        }

        public object SkillMaster_Get_GetByID(int SkillIDP)
        {
            return new SqlHelper().GetJsonObject("SkillMaster_Get_GetByID", new object[,]
            {
                {"SkillIDP",SkillIDP }
            });
        }

        public object SkillMaster_Get_GetAll()
        {
            return new SqlHelper().GetJsonObject("SkillMaster_Get_GetAll", new object[,] { });
        }

        public MEMBERS.SQLReturnMessageNValue SkillMaster_Insert_Update(SkillMasterClass oClass)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("SkillMaster_Insert_Update", new object[,]
            {
                {"SkillIDP",oClass.SkillIDP },
                {"SkillName",oClass.SkillName },
                {"UserIDF",oClass.CreatedBy }
            });
        }

        public MEMBERS.SQLReturnMessageNValue SkillMaster_GeneralAction(int SkillIDP,int ActionType,Guid UserIDF)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("SkillMaster_GeneralAction", new object[,]
            {
                {"SkillIDP",SkillIDP },
                {"ActionType",ActionType },
                {"UserIDF", UserIDF },
            });
        }
    }
}
