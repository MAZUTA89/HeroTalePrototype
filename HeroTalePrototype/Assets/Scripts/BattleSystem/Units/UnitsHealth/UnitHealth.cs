using System;
using System.Collections.Generic;
using UnityEngine.WSA;

namespace HTP.Units
{
    public class UnitHealth
    {
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
        public UnitHealth(IUnitSO unitSO)
        {
            _maxHealth = unitSO.HP;
            Health = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
        }

        public void HealHP(float hp)
        {
            Health += hp;
        }
    }
}
