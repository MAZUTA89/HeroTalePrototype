using System;
using UnityEngine;

namespace HTP.Units
{
    [CreateAssetMenu(fileName ="Unit", menuName ="SO/Units/Unit")]
    public class UnitSO : ScriptableObject, IUnitSO
    {
        [SerializeField] private string _id;
        [Range(80, 500)]
        [SerializeField] private int _hp;
        [Range(5, 200)]
        [SerializeField] private float _armor;
        [Range(5, 200)]
        [SerializeField] private float _strength;
        [Range(1, 10)]
        [SerializeField] private float _preparationTime;

        [Range(0.3f, 1f)]
        [SerializeField] private float _weaponSpeedInfluenceRatio;

        [Range(0, 100)]
        [SerializeField] private float _spawnChance = 20;


        public string Id => _id;
        public int HP => _hp;
        public float Armor => _armor;
        public float Strength => _strength;
        public float PreparationTime => _preparationTime;
        public float WeaponSpeedInfluenceRatio => _weaponSpeedInfluenceRatio;

        public float SpawnChance => _spawnChance;
    }
}
