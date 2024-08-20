using HTP.Units;
using System;
using System.Collections.Generic;
using static UnityEditor.Timeline.Actions.MenuPriority;

namespace HTP.Machine.States
{
    public class ChangeItemInAttackState : ChangeItemInPreparationState
    {
        Player _player;
        public ChangeItemInAttackState(StateMachine stateMachine)
            : base(stateMachine)
        {
            _player = Unit as Player;
        }
        public override void Enter()
        {
            base.Enter();
            
           /* Unit.Animator.Play($"take_{Unit.Item.Id}")*/;
        }
        protected override void OnEndTime()
        {
            _player.ChangeWeapon();
            StateMachine.ChangeState(Unit.BattlePreparationState);
        }
    }
}
