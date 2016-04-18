using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace RuleEngine
{
    public interface ICondition
    {
        Common.LogicalOperation Operation { get; }
        bool Validate(WorkItem obj);
    }
}
