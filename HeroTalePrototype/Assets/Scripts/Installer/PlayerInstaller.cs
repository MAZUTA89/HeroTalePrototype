using System;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using HTP.Units;
using HTP.Inventories;

namespace HTP.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private UnitSO _playerUnitSO;
        public override void InstallBindings()
        {
            Container.Bind<Unit>().To<Player>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<UnitSO>()
                .FromInstance(_playerUnitSO);

            Container.Bind<ItemHolder>()
                .FromComponentInChildren()
                .AsSingle();
        }
    }
}
