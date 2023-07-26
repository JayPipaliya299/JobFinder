using SQLClass;
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

        public object EmployeeMaster_Get_GetByID(int EmployeeIDP)
        {
            return new SqlHelper().GetJsonObject("EmployeeMaster_Get_GetByID", new object[,]
            {
                {"EmployeeIDP",EmployeeIDP }
            });
        }
        public MEMBERS.SQLReturnMessageNValue EmployeeMaster_Insert_Update(EmployeeMasterClass oClass)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("EmployeeMaster_Insert_Update", new object[,]
            {
                {"EmployeeIDP", oClass.EmployeeIDP }
                , {"EmployeeName", oClass.EmployeeName}
                , {"EmployeeAge", oClass.EmployeeAge}
                , {"EmployeeEmail", oClass.EmployeeEmail}
                , {"EmployeeMobileNumber", oClass.EmployeeMobileNumber}
                , {"EmployeeGender", oClass.EmployeeGender}
                , {"CountryIDF", oClass.CountryIDF}
                , {"StateIDF", oClass.StateIDF}
                , {"CityIDF",oClass.CityIDF}
                , {"JobExperienceIDF", oClass.JobExperienceIDF}
                , {"SkillIDF", oClass.SkillIDF}
                , {"EmployeeDomain", oClass.EmployeeDomain}
                , {"UserIDF", oClass.CreatedBy}
            });
        }

        public MEMBERS.SQLReturnMessageNValue EmployeeMaster_GeneralAction(int EmployeeIDP,int ActionType,Guid UserIDF)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("EmployeeMaster_GeneralAction", new object[,]
            {
                {"EmployeeIDP",EmployeeIDP },
                {"ActionType",ActionType},
                {"UserIDF",UserIDF}
            });
        }
    }
}
