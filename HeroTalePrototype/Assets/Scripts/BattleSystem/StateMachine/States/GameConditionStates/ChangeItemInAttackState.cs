using System;
using System.Collections.Generic;
using static UnityEditor.Timeline.Actions.MenuPriority;

namespace HTP.Machine.States
{
    public class ChangeItemInAttackState : ChangeItemInPreparationState
    {
        public ChangeItemInAttackState(StateMachine stateMachine)
            : base(stateMachine)
        {
        }

        protected override void OnEndTime()
        {
            base.OnEndTime();
            Unit.Animator.Play($"take_{Unit.Item.Id})");
            StateMachine.ChangeState(Unit.BattlePreparationState);
        }
    }
}
