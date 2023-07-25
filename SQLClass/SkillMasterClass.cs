using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class SkillMasterClass
    {
        public int SkillIDP { get; set; }
        public string SkillName { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }

    public class SkillEmployeeClass
    {
        public int SkillIDP { get; set; }
        public string SkillName { get; set; }
    }
}
