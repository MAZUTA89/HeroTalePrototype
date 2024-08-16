using System;
using System.Collections.Generic;

namespace HTP.Machine.States
{
    public class AttackState : DependonTimerState
    {
        public AttackState(StateMachine stateMachine)
            : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Unit.StartAttack();
            StateUI.ActivateAttackIcon();
        }

        protected override void OnEndTime()
        {
            base.OnEndTime();
            StateMachine.ChangeState(Unit.BattlePreparationState);
        }
    }
}
