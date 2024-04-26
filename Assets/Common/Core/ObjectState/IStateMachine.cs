namespace Common.Core.ObjectState
{
    public interface IStateMachine
    {
        IStateMachine ApplyAndNextState();
    }
}