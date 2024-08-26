using HTP.Inventories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HTP.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Inventory>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<InventoryUI>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Cell>()
                .FromComponentInHierarchy()
                .AsTransient();
            Container.BindInterfacesAndSelfTo<HudCell>()
                .FromComponentInChildren()
                .AsTransient();
        }
    }
}

