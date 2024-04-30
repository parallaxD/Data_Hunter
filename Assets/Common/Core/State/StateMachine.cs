using System;
using System.Collections.Generic;

namespace Common.Core.State
{
    public abstract class StateMachine
    {
        protected Dictionary<Type, State> States = new ();
        protected State Current;
        
        public void SetState<T>() where T : State
        {
            Current = States[typeof(T)];
        }

        public void Update()
        {
            Current.Apply();
        }

        protected void AddState(State state)
        {
            States[state.GetType()] = state;
        }
    }
}