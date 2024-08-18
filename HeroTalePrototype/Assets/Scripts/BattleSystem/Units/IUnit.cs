using HTP.Inventories;
using HTP.Machine.States;
using HTP.Units;
using System.Collections;
using System.Collections.Generic;
using UI.StateUI;
using UnityEngine;

public interface IUnit
{
    Animator Animator { get; }
    IUnitSO UnitSO { get; }
    StateUI StateUI { get; }
    Item Item { get; }

    IUnitState BattlePreparationState { get; }
    IUnitState AttackState { get; }

    void StartAttack();
    void StartPrepare();
}
