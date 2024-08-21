using HTP.BattleSystem;
using HTP.UI;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using HTP.Units;
using HTP.SceneControls;

namespace HTP.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private List<Enemy> _enemiesTemplate;
        [SerializeField] private Transform _enemySpawnPoint;
        public override void InstallBindings()
        {
            Container.Bind<BattleService>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<HudUI>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<AlignWithScreenPoint>()
                .AsTransient();

            Container.Bind<GameSceneController>()
                .FromComponentInHierarchy()
                .AsSingle();

            BindEnemySpawner();
        }

        void BindEnemySpawner()
        {
            List<IEnemyFactory> enemyFactories = new List<IEnemyFactory>();

            foreach (var enemy in _enemiesTemplate)
            {
                IEnemyFactory enemyFactory = new EnemyFactory
                    (Container, _enemySpawnPoint, enemy);

                enemyFactories.Add(enemyFactory);
            }

            EnemySpawner enemySpawner = new EnemySpawner(enemyFactories);

            Container.BindInstance(enemySpawner).AsSingle();
        }
    }
}
