using HTP.Machine.States;
using System;
using System.Collections.Generic;

namespace HTP.Machine
{ 
    public class StateMachine
    {
        IUnitState _currentState;
        IUnitState _lastState;
        
        public IUnit Unit { get; protected set; }
        
        public void Initialize(IUnit unit)
        {
            Unit = unit;
        }
        public void ChangeState(IUnitState newState)
        {
            _currentState.Exit();
            newState.Enter();
            _lastState = _currentState;
            _currentState = newState;
        }
        public void Update()
        {
            _currentState.Perform();
        }
    }
}
