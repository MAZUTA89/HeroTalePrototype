using System;
using System.Collections.Generic;

namespace HTP.Units
{
    public interface IWeaponSO
    {
        string Id { get; }
        float Damage { get; }
        float Speed { get; }
    }
}
