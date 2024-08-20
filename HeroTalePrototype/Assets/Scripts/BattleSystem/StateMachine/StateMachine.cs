using HTP.Machine.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Machine
{
    public class StateMachine
    {
        Action _action;
        bool _isWait;
        float _waitTime;
        float _currentWaitTime;
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
            if (_isWait == false)
            {
                CurrentState?.Perform();
            }
            if(_isWait)
            {
                _currentWaitTime += Time.deltaTime;
            }

            if (_currentWaitTime >= _waitTime)
            {
                _isWait = false;
                _action?.Invoke();
            }
        }

        public void WaitAndAction(float waitTime, Action action)
        {
            _waitTime = waitTime;
            _isWait = true;
            _currentWaitTime = 0;
        }
    }
}
