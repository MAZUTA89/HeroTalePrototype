using System;
using System.Collections.Generic;
using UI.StateUI;
using UnityEngine;
using UnityEngine.UI;

namespace HTP.Machine.States
{
    public class DependonTimerState : UnitState
    {
        protected const float c_maxFillAmount = 1;
        protected const float c_minFillAmount = 0;
        protected float TargetTime;
        protected float ElapsedTime;
        protected StateUI StateUI;
        protected Image TimerImage;
        private float _currentValue;
        
        public DependonTimerState(StateMachine stateMachine)
            : base(stateMachine)
        {
            StateUI = Unit.StateUI;
            TimerImage = StateUI.TimerImage;
        }

        public override void Enter()
        {
            base.Enter();
            TargetTime = Unit.UnitSO.PreparationTime;
            ElapsedTime = c_minFillAmount;
            StateUI.gameObject.SetActive(true);
        }

        public override void Perform()
        {
            base.Perform();
            ElapsedTime += Time.deltaTime;
            _currentValue = Mathf.Lerp(c_maxFillAmount, c_minFillAmount,
                 ElapsedTime / TargetTime);
            TimerImage.fillAmount = _currentValue;

            if(_currentValue <= c_minFillAmount)
            {
                ElapsedTime = TargetTime;
                OnEndTime();
            }
        }

        protected virtual void OnEndTime()
        {

        }


    }
}
