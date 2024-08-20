using System;
using System.Collections.Generic;
using UI.StateUI;

namespace HTP.Units
{
    public class UnitHealth
    {
        public bool IsAlive
        {
            get
            {
                return _currentHealth != 0;
            }
        }
        float _maxHealth;
        public float Health
        {
            get
            { 
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
                if(_currentHealth < 0)
                {
                    _currentHealth = 0;
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
        }

        public void HealHP(float hp)
        {
            Health += hp;
            _unitInfoUI.SetHealthValue(Health);
        }
    }
}
