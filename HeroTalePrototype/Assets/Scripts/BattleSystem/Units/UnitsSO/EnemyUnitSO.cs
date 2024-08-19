using HTP.Inventories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Units
{
    [CreateAssetMenu(fileName = "EnemyUnit", menuName = "SO/Units/EnemyUnit")]
    public class EnemyUnitSO : UnitSO
    {
        public WeaponSO Weapon;
    }
}
