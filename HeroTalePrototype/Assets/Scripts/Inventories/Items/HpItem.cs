using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Inventories
{
    [CreateAssetMenu(fileName = "HpItem", menuName = "SO/Items/HpItem")]
    public class HpItem : Item
    {
        [Range(1, 50)]
        public float HP;
        public override void Apply()
        {
            Player.UnitHealth.HealHP(HP);
        }

        public override bool ApplyCondition()
        {
            return true;
        }
    }
}
