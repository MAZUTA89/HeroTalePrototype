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
        }

        public override void Perform()
        {
            base.Perform();

        }
        protected override void OnEndTime()
        {
            base.OnEndTime();


        }
    }
}
