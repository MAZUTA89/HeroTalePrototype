﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Inventories
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "SO/Items/Weapon")]
    public class WeaponSO : Item, IWeaponSO
    {
        [Range(10, 100)]
        [SerializeField] private int _damage;
        [Range(1f, 5f)]
        [SerializeField] private float _speed;

        public float Damage => _damage;

        public float Speed => _speed;

        public override void Apply()
        {
            
            Player.SetItem(this);
        }

        public override bool ApplyCondition()
        {
            return true;
        }
    }
}
