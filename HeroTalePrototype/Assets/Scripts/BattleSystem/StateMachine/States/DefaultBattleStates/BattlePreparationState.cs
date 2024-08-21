using HTP.Inventories;
using System;
using System.Collections.Generic;

namespace HTP.Machine.States
{
    public class BattlePreparationState : DependonTimerState
    {
        public BattlePreparationState(StateMachine stateMachine)
            : base(stateMachine)
        {

        }
        public override void Enter()
        {
            base.Enter();
            Unit.StartPrepare();
            StateUI.ActivatePrepareIcon();
        }

        public override void Perform()
        {
            base.Perform();

        }
        protected override void OnEndTime()
        {
            base.OnEndTime();
            StateMachine.ChangeState(Unit.AttackState);
        }
    }
}
