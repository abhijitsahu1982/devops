using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class Group
    {
        
        public string Operation { get; set; }

        public IList<Condition> Condition { get; set; }

        }
}
