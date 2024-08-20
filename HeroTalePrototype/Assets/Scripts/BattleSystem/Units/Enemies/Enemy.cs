using HTP.Inventories;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public class Enemy : Unit
    {
        [SerializeField] private EnemyUnitSO _unitSO;

        protected override void Start()
        {
            UnitData = _unitSO;
            base.Start();
            UnitHealth.Initialize(UnitSO, UnitsInfoUI.EnemyInfo);
            UnitsInfoUI.EnemyInfo.NameText.text = UnitSO.Id;
        }

        protected Player Player;
        [Inject]
        public void ConstructEnemy(Player player)
        {
            Player = player;
        }

        public override void OnDealDamage()
        {
            base.OnDealDamage();

            //Player.UnitHealth.TakeDamage(_unitSO.Weapon.Damage);
            Player.TakeDamage(_unitSO.Weapon.Damage);
        }

        public override void OnDeadAnimation()
        {
            base.OnDeadAnimation();

            BattleService.OnEnemyDead();
        }

        public float GetSpawnChance()
        {
            return _unitSO.SpawnChance;
        }
    }
}
