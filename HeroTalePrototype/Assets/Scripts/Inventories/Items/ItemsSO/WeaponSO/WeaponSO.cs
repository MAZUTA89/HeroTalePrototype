using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Inventories
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "SO/Items/Weapon")]
    public class WeaponSO : Item, IWeaponSO
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;

        public float Damage => _damage;

        public float Speed => _speed;

        public override void Apply()
        {
            Player.Animator.Play($"take_{Id}");
            Player.SetItem(this);
        }

        public override bool ApplyCondition()
        {
            return true;
        }
    }
}
