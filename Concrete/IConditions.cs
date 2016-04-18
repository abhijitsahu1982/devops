using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace RuleEngine
{  
    public interface IConditions
    {
        Common.LogicalOperation Operation { get; }
        void AddCondition(string fieldName, string operatorName, string value);
        bool Validate(WorkItem obj);
    }
}
