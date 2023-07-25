using SQLClass;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class StateMasterLogic
    {
        public object StateMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            return new SqlHelper().GetJsonObject("StateMaster_Get_GetAllPagging", new object[,]
            {
                {"RowsPerPage",RowsPerPage }
                , {"PageNumber", PageNumber}
            });
        }

        public object StateMaster_Get_GetByID(int StateIDP)
        {
            return new SqlHelper().GetJsonObject("StateMaster_Get_GetByID", new object[,]
            {
                {"StateIDP",StateIDP }
            });
        }

        public object StateMaster_Get_GetAll()
        {
            return new SqlHelper().GetJsonObject("StateMaster_Get_GetAll", new object[,] { });
        }

        public object StateMaster_Get_GetStateByCountryIDP(int CountryIDP)
        {
            return new SqlHelper().GetJsonObject("StateMaster_Get_GetStateByCountryIDP", new object[,]
            {
                { "CountryIDP",CountryIDP }
            });
        }

        public MEMBERS.SQLReturnMessageNValue StateMaster_Insert_Update(StateMasterClass oClass)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("StateMaster_Insert_Update", new object[,]
            {
                {"StateIDP", oClass.StateIDP }
                , {"StateName", oClass.StateName}
                , {"CountryIDF", oClass.CountryIDF}
                , {"UserIDF", oClass.CreatedBy}
            });
        }

        public MEMBERS.SQLReturnMessageNValue StateMaster_GeneralAction(int StateIDP, int ActionType,Guid UserIDF)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("StateMaster_GeneralAction", new object[,]
            {
                {"StateIDP", StateIDP }
                , {"ActionType", ActionType }
                , {"UserIDF", UserIDF}
            });
        }
    }
}
