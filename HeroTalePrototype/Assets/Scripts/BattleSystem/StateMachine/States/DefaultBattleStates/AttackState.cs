using HTP.Inventories;
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
            
            StateUI.ActivateAttackIcon();
            if (Unit.Item is WeaponSO weapon)
            {
                TargetTime = Unit.UnitSO.PreparationTime / (1 +
                    Unit.UnitSO.WeaponSpeedInfluenceRatio *
                    weapon.Speed);
            }
        }

        protected override void OnEndTime()
        {
            base.OnEndTime();
            Unit.StartAttack();
            StateMachine.ChangeState(Unit.BattlePreparationState);
        }
    }
}
