using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class Condition
    {
        public string LogicalOperation { get; set; }

        public string FieldName { get; set; }

        public string Operation { get; set; }

        public string Value { get; set; }
    }
}
