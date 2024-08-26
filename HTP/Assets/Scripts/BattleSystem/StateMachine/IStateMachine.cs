using HTP.Machine.States;
using System;
using System.Collections.Generic;

namespace HTP.Machine
{
    public interface IStateMachine<T>
    {
        public T Unit { get; }
        void Initialize(T unit);
         void Update();

         void ChangeState(IUnitState state);
    }
}
