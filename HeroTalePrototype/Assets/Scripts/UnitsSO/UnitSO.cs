using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Units
{
    [CreateAssetMenu(fileName ="Unit", menuName ="SO/Units/Unit")]
    public class UnitSO : ScriptableObject, IUnitSO
    {
        [SerializeField] private string _id;
        [SerializeField] private int _hp;
        [SerializeField] private float _armor;
        [SerializeField] private float _strength;
        [SerializeField] private float _preparationTime;
        [SerializeField] private GameObject _unitPrefab;

        public string Id => _id;
        public int HP => _hp;
        public float Armor => _armor;
        public float Strength => _strength;
        public float PreparationTime => _preparationTime;
        public GameObject UnitPrefab => _unitPrefab;
    }
}
