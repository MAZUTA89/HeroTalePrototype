using HTP.Machine;
using UnityEngine;

namespace HTP.Machine.States
{
    public abstract class UnitState : IUnitState
    {
        protected StateMachine StateMachine;
        protected IUnit Unit;
        public UnitState(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Unit = StateMachine.Unit;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {

        }

        public virtual void Perform()
        {
        }
    }
}

