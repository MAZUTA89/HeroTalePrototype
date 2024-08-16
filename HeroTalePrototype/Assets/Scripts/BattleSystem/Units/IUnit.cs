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
    IWeaponSO WeaponSO { get; }

    IUnitState BattlePreparationState { get; }
    IUnitState AttackState { get; }

    void StartAttack();
    void StartPrepare();
}
