using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Units
{
    public class Enemy : Unit
    {
        [SerializeField] private UnitSO _unitSO;

        protected override void Start()
        {
            UnitData = _unitSO;
            base.Start();
        }
    }
}
