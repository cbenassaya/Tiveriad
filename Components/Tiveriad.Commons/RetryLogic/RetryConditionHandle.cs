namespace Tiveriad.Commons.RetryLogic
{
    public class RetryConditionHandle
    {
        public RetryConditionHandle(RetryContext context, RetryCondition condition)
        {
            Context = context;
            Condition = condition;
        }

        public DateTimeOffset FirstOccured { get; internal set; }
        public uint Occurences { get; internal set; }
        
        public RetryContext Context { get; private set; }
        public RetryCondition Condition { get; private set; }
    }
}
