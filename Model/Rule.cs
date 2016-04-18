using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class Rule
    {
        public string Name { get; set; }

        public string PreCondiction { get; set; }

        public IList<Group> ConditionGroup { get; set; }

        public IList<Action> Action { get; set; }
    }
}
