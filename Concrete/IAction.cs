using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace RuleEngine
{
    public delegate decimal ActionPredicate<in T>(T obj);

    public interface IAction
    {
        string Key { get; }
        string FieldName { get; }
        string OperatorName { get; }
        string Value { get; }
        decimal Execute(WorkItem obj, IDictionary<string, decimal> state);
    }
}
