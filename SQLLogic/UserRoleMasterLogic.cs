using SQLClass;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class UserRoleMasterLogic
    {
        public MEMBERS.SQLReturnMessageNValue UserRoleMaster_Insert(UserRoleMasterClass oClass)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("UserRoleMaster_Insert", new object[,]
            {
                {"UserID", oClass.UserID }
                , {"RoleID", oClass.RoleID}
            });
        }
    }
}
