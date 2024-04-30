namespace Common.Core.State
{
    public abstract class State
    {
        protected StateMachine StateMachine { get; }

        protected State(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        
        public abstract void Apply();
    }
}