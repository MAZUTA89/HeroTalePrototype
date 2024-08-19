using System;
using System.Collections.Generic;


namespace UI.StateUI
{
    public class UnitsInfoUI
    {
        public UnitInfoUI PlayerInfo { get; private set; }
        public UnitInfoUI EnemyInfo { get; private set; }

        public UnitsInfoUI(UnitInfoUI playerInfo,
            UnitInfoUI enemyInfo)
        {
            PlayerInfo = playerInfo;
            EnemyInfo = enemyInfo;
        }
    }
}
