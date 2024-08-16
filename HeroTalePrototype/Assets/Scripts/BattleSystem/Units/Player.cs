using HTP.Machine;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public class Player : Unit
    {
        protected StateMachine StateMachine;

       

        protected override void Start()
        {
            base.Start();

            StateMachine = new StateMachine();

            StateMachine.Initialize(this);
        }

        private void Update()
        {
            StateMachine.Update();
        }

        public override void StartAttack()
        {
        }

        public override void StartPrepare()
        {
        }
    }
}
