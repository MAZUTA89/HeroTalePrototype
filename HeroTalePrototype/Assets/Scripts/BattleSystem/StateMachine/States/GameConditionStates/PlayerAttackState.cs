using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP.Machine.States
{
    public class PlayerAttackState : AttackState
    {
        public PlayerAttackState(StateMachine stateMachine)
            : base(stateMachine)
        {
        }

        protected override void OnEndTime()
        {
            base.OnEndTime();
        }
    }
}
