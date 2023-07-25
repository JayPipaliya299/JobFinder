using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLogic
{
    public class JobExperienceLogic
    {
        public object JobExperience_Get_GetAll()
        {
            return new SqlHelper().GetJsonObject("JobExperience_Get_GetAll", new object[,] { });
        }
    }
}
