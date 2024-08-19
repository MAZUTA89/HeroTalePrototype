using System;
using System.Collections.Generic;
using UI.StateUI;

namespace HTP.Units
{
    public class UnitHealth
    {
        public event Action OnTakeDamageEvent;

        float _maxHealth;
        public float Health
        {
            get
            { 
                return _maxHealth;
            }
            set
            {
                _maxHealth = value;
                if(_maxHealth < 0)
                {
                    _maxHealth = 0;
                }
            }
        }
        float _currentHealth;
        UnitInfoUI _unitInfoUI;
        IUnitSO _unitSO;

        public UnitHealth()
        {
            
        }
        public void Initialize(IUnitSO unitSO, UnitInfoUI unitInfoUI)
        {
            _maxHealth = unitSO.HP;
            Health = _maxHealth;
            _unitInfoUI = unitInfoUI;
            unitInfoUI.HealthSlider.maxValue = _maxHealth;
            unitInfoUI.HealthSlider.minValue = 0f;
            unitInfoUI.SetHealthValue(Health);
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            _unitInfoUI.SetHealthValue(Health);
            OnTakeDamageEvent?.Invoke();
        }

        public void HealHP(float hp)
        {
            Health += hp;
            _unitInfoUI.SetHealthValue(Health);
        }
    }
}
