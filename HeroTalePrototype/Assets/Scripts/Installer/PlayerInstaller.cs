using System;
using Zenject;
using UnityEngine;
using HTP.Units;
using UI.StateUI;

namespace HTP.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private UnitInfoUI _playerInfoUI;
        [SerializeField] private UnitInfoUI _enemyInfoUI;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Player>()
                .FromComponentInHierarchy()
                .AsSingle();
           

            Container.Bind<ItemHolder>()
                .FromComponentInChildren()
                .AsSingle();

            UnitsInfoUI unitsInfoUI = new UnitsInfoUI(_playerInfoUI, _enemyInfoUI);

            Container.BindInstance(unitsInfoUI).AsSingle();

            Container.BindInterfacesAndSelfTo<Enemy>().AsTransient();

            //Container.Bind<GameUnits>().AsSingle();
        }
    }
}
