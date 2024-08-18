using System;
using System.Collections.Generic;

namespace HTP.Inventories
{
    public interface IWeaponSO : IItemSO
    {
        float Damage { get; }
        float Speed { get; }
    }
}
