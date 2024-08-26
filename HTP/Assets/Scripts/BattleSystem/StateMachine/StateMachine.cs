using HTP.Machine.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Machine
{
    public class StateMachine
    {
        public IUnitState CurrentState { get; private set; }
        IUnitState _lastState;

        public IUnit Unit { get; protected set; }

        public void Initialize(IUnit unit)
        {
            Unit = unit;
        }
        public void ChangeState(IUnitState newState)
        {
            CurrentState?.Exit();
            newState.Enter();
            _lastState = CurrentState;
            CurrentState = newState;
        }
        public void ChangeStateWithOutEnter(IUnitState newState)
        {
            CurrentState?.Exit();
            _lastState = CurrentState;
            CurrentState = newState;
        }
        public void Update()
        {
            CurrentState?.Perform();
        }
    }
}
