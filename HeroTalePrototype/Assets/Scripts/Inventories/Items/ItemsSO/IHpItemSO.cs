using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Inventories
{
    public interface IHpItemSO : IItemSO
    {
        float HP { get; }
    }
}
