using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class UserMasterLogic
    {
        public object UserMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            return new SqlHelper().GetJsonObject("UserMaster_Get_GetAllPagging", new object[,] {
                { "RowsPerPage",RowsPerPage }
                , { "PageNumber",PageNumber }
            });
        }

        public object UserMaster_Get_GetByID(string ID)
        {
            return new SqlHelper().GetJsonObject("UserMaster_Get_GetByID", new object[,]
            {
                {"ID",ID }
            });
        }

        public object UserMaster_Check(string Email)
        {
            return new SqlHelper().GetJsonObject("UserMaster_Check", new object[,]
            {
                { "Email", Email }
            });
        }
    }
}
