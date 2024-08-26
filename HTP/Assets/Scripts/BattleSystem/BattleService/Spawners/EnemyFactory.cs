using HTP.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HTP.BattleSystem
{
    public class EnemyFactory : IEnemyFactory
    {
        public Enemy Template => _template;

        IInstantiator _instantiator;
        Transform _spawnPoint;
        Enemy _template;

        public EnemyFactory(IInstantiator instantiator, Transform spawnPoint,
            Enemy template) 
        {
            _instantiator = instantiator;
            _spawnPoint = spawnPoint;
            _template = template;
        }
        public Enemy Create()
        {
            return _instantiator.InstantiatePrefabForComponent<Enemy>
                (_template, _spawnPoint.position, _template.transform.rotation,
                null);
        }
    }
}
