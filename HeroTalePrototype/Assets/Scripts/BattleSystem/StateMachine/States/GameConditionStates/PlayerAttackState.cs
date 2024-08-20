using HTP.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP.Machine.States
{
    public class PlayerAttackState : AttackState
    {
        Player _player;
        public PlayerAttackState(StateMachine stateMachine)
            : base(stateMachine)
        {
            _player = Unit as Player;
        }

        protected override void OnEndTime()
        {
            if(_player.IsChangeWeaponInAttackState)
            {
                Unit.StartAttack();
                StateMachine.ChangeState(
                    _player.ChangeItemInAttackState);
            }
            else
            {
                base.OnEndTime();
            }
        }
    }
}
