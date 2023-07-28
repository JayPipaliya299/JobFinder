using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class RoleMasterLogic
    {
        public object RoleMaster_Get_GetAll()
        {
            return new SqlHelper().GetJsonObject("RoleMaster_Get_GetAll", new object[,] { });
        }
    }
}
