#region

using System.Linq.Expressions;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface ISubscriptionStep
{
    string EventName { get; set; }
    LambdaExpression EventKey { get; set; }
}

public interface ISubscriptionStep<TStepBody> : ISubscriptionStep
    where TStepBody : ISubscriptionBody
{
}