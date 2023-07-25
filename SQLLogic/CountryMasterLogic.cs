using SQLClass;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class CountryMasterLogic
    {
        public object CountryMaster_Get_GetAllPagging(int RowsPerPage, int PageNumber)
        {
            return new SqlHelper().GetJsonObject("CountryMaster_Get_GetAllPagging", new object[,] {
                { "RowsPerPage",RowsPerPage }
                , { "PageNumber",PageNumber }
            });
        }

        public object CountryMaster_Get_GetByID(int CountryIDP)
        {
            return new SqlHelper().GetJsonObject("CountryMaster_Get_GetByID", new object[,] {
                { "CountryIDP",CountryIDP }
            });
        }

        public object CountryMaster_Get_GetAll()
        {
            return new SqlHelper().GetJsonObject("CountryMaster_Get_GetAll", new object[,] { });
        }

        public MEMBERS.SQLReturnMessageNValue CountryMaster_Insert_Update(CountryMasterClass oClass)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("CountryMaster_Insert_Update", new object[,] { 
                { "CountryIDP", oClass.CountryIDP }
                , { "CountryName", oClass.CountryName }
                , { "UserIDF" , oClass.CreatedBy}
            });
        }

        public MEMBERS.SQLReturnMessageNValue CountryMaster_GeneralAction(int CountryIDP, int ActionType, Guid UserIDF)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("CountryMaster_GeneralAction", new object[,]
            {
                { "CountryIDP",CountryIDP }
                , { "ActionType", ActionType}
                , {"UserIDF", UserIDF}
            });
        }
    }
}
