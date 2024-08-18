using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Inventories
{
    [CreateAssetMenu(fileName = "HpItem", menuName = "SO/Items/HpItem")]
    public class HpItem : Item
    {
        public override void Apply()
        {
        }

        public override bool ApplyCondition()
        {
            return false;
        }
    }
}
