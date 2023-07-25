using SQLClass;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class CityMasterLogic
    {
        public object CityMaster_Get_GetAllPagging(int RowsPerPage,int PageNumber)
        {
            return new SqlHelper().GetJsonObject("CityMaster_Get_GetAllPagging", new object[,]
            {
                {"RowsPerPage",RowsPerPage },
                {"PageNumber", PageNumber }
            });
        }

        public object CityMaster_Get_GetByID(int CityIDP)
        {
            return new SqlHelper().GetJsonObject("CityMaster_Get_GetByID", new object[,]
            {
                {"CityIDP",CityIDP }
            });
        }
        public object CityMaster_Get_GetAll()
        {
            return new SqlHelper().GetJsonObject("CityMaster_Get_GetAll", new object[,] { });
        }
        public object CityMaster_Get_GetCityByStateIDP(int StateIDP)
        {
            return new SqlHelper().GetJsonObject("CityMaster_Get_GetCityByStateIDP", new object[,]
            {
                { "StateIDP",StateIDP }
            });
        }

        public MEMBERS.SQLReturnMessageNValue CityMaster_Insert_Update(CityMasterClass oClass)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("CityMaster_Insert_Update", new object[,]
            {
                {"CityIDP", oClass.CityIDP },
                {"StateIDF", oClass.StateIDF },
                {"CityName", oClass.CityName },
                {"UserIDF", oClass.CreatedBy },
            });
        }

        public MEMBERS.SQLReturnMessageNValue CityMaster_GeneralAction(int CityIDP, int ActionType,Guid UserIDF)
        {
            return new SqlHelper().ExecuteProceduerWithMessageNValue("CityMaster_GeneralAction", new object[,]
            {
                {"CityIDP", CityIDP },
                {"ActionType", ActionType },
                {"UserIDF", UserIDF }
            });
        }
    }
}
