using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class Action
    {
        public string FieldName { get; set; }

        public string Operation { get; set; }

        public string Key { get; set; }

        public string Data { get; set; }
    }
}
