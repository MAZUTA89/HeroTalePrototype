using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTP.Machine.States
{
    public class DeadState : DependonTimerState
    {
        public DeadState(StateMachine stateMachine) : base(stateMachine)
        {
        }


        public override void Enter()
        {
            StateUI.TimerImage.fillAmount = c_maxFillAmount;
            Unit.StartPrepare();
        }
        public override void Perform()
        {
        }
        public override void Exit()
        {
        }
    }
}
