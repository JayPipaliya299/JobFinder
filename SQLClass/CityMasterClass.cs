using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class CityMasterClass
    {
        public int CityIDP { get; set; }
        public string CityName { get; set; }
        public int StateIDF { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }

    public class CityEmployeeClass
    {
        public int CityIDP { get;set; }
        public string CityName { get; set; }
    }
}
