﻿using System;
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
            
            StateUI.ActivateAttackIcon();
        }

        protected override void OnEndTime()
        {
            base.OnEndTime();
            Unit.StartAttack();
            StateMachine.ChangeState(Unit.BattlePreparationState);
        }
    }
}
