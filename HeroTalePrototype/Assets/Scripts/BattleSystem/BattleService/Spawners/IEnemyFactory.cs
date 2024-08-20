using HTP.Units;
using System;
using System.Collections.Generic;

namespace HTP.BattleSystem
{
    public interface IEnemyFactory
    {
        Enemy Template { get; }
        Enemy Create();
    }
}
