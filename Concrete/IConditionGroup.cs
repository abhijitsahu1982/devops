using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace RuleEngine
{
    public interface IConditionGroup
    {
        void AddCondition(int count, string fieldName, string operatorName, string value, Common.LogicalOperation logicalOperation = Common.LogicalOperation.AND);
        Common.LogicalOperation Operation { get; }
        bool Validate(WorkItem obj);
    }
}
