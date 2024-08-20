using HTP.Units;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.BattleSystem
{
    public class EnemySpawner
    {
        List<IEnemyFactory> _enemyFactories;
        public EnemySpawner(List<IEnemyFactory> enemyFactories)
        {
            _enemyFactories = enemyFactories;
        }

        public Enemy Spawn()
        {
            float totalWeight = 0;

            foreach (IEnemyFactory factory in _enemyFactories)
            {
                totalWeight += factory.Template.UnitSO.SpawnChance;
            }


            float randomWeight = Random.Range(0, totalWeight);
            float currentWeight = 0;

            foreach(IEnemyFactory factory in _enemyFactories)
            {
                currentWeight += factory.Template.UnitSO.SpawnChance;

                if(randomWeight < currentWeight)
                {
                    return factory.Create();
                }
                break;
            }

            return null;
        }

    }
}
