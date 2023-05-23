//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;

public class Missable<T>
{
    private T value;

    public Missable()
    {
        IsMissing = true;
    }

    public Missable(T value)
    {
        Value = value;
    }

    public bool IsMissing { get; private set; }

    public T Value
    {
        get
        {
            if (IsMissing) throw new InvalidOperationException("a missing value cannot be accessed.");

            return value;
        }

        private set
        {
            this.value = value;

            IsMissing = false;
        }
    }
}