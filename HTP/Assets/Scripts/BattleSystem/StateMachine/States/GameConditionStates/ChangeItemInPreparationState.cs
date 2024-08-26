using System;
using System.Collections.Generic;


namespace HTP.Machine.States
{
    public class ChangeItemInPreparationState : DependonTimerState
    {
        public ChangeItemInPreparationState(StateMachine stateMachine)
            : base(stateMachine)
        {
        }

        public override void Enter()
        {
            TargetTime = 2;
            ElapsedTime = c_minFillAmount;
        }

        protected override void OnEndTime()
        {
            base.OnEndTime();
            StateMachine.ChangeStateWithOutEnter(Unit.BattlePreparationState);
        }
    }
}
