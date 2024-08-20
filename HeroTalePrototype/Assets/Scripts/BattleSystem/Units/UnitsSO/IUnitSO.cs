using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Units
{
    public interface IUnitSO 
    {
        string Id { get; }
        int HP { get; }
        float Armor { get; }
        float Strength { get; }
        float PreparationTime { get; }
        float SpawnChance { get; }
        GameObject UnitPrefab { get; }
    }
}

