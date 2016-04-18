using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace RuleEngine
{
    public interface IRule
    {
        string RuleName { get; }        
        //void AddCondition(int count,string fieldName, string operatorName, string value, Common.LogicalOperation logicalOperation = Common.LogicalOperation.AND);
        void AddConditionGroup(RuleConditionGroup group, Common.LogicalOperation logicalOperation = Common.LogicalOperation.AND);
        void AddAction(string fieldName, string operatorName, string value, string actionKey = null);
        bool Run(WorkItem obj);
    }
}
