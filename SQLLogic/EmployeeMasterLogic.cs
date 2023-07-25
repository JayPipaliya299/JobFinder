using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class EmployeeMasterLogic
    {
        public object EmployeeMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            return new SqlHelper().GetJsonObject("EmployeeMaster_Get_GetAllPagging", new object[,]
            {
                {"RowsPerPage",RowsPerPage },
                {"PageNumber",PageNumber }
            });
        }
    }
}
