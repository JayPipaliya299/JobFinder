using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class CountryMasterClass
    {
        public int CountryIDP { get; set; }
        public string CountryName { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }

    public class CountryStateClass
    {
        public int CountryIDP { get; set; }
        public string CountryName { get; set; }
    }
}
