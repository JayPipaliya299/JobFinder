using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class StateMasterClass
    {
        public int StateIDP { get; set; }
        public string StateName { get; set; }
        public int CountryIDF { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set;}
    }

    public class StateCityClass
    {
        public int StateIDP { get; set; }
        public string StateName { get; set; }
    }
}
