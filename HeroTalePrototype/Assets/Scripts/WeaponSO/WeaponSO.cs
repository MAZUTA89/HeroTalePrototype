using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Units
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "SO/Weapons/Weapon")]
    public class WeaponSO : IWeaponSO
    {
        [SerializeField] private string _id;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        public string Id => _id;

        public float Damage => _damage;

        public float Speed => _speed;
    }
}
