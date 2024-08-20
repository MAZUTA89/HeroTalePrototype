using HTP.Inventories;
using System;
using System.Collections.Generic;
using UI.StateUI;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public class Enemy : Unit
    {
        [SerializeField] EnemyUnitSO _enemyUnitSO;
        UnitInfoUI _enemyInfoUI;
        protected override void Start()
        {
            base.Start();
            UnitHealth.Initialize(UnitSO, UnitsInfoUI.EnemyInfo);
            _enemyInfoUI = UnitsInfoUI.EnemyInfo;
            _enemyInfoUI.gameObject.SetActive(true);
            _enemyInfoUI.NameText.text = UnitSO.Id;
            StateMachine.ChangeState(BattlePreparationState);
        }

        protected Player Player;

        public override IUnitSO UnitSO => _enemyUnitSO;

        [Inject]
        public void ConstructEnemy(Player player)
        {
            Player = player;
        }

        public override void OnDealDamage()
        {
            base.OnDealDamage();

            //Player.UnitHealth.TakeDamage(_unitSO.Weapon.Damage);
            Player.TakeDamage(_enemyUnitSO.Weapon.Damage);
        }

        public override void OnDeadAnimation()
        {
            base.OnDeadAnimation();

            BattleService.OnEnemyDead();
        }


        private void OnDestroy()
        {
            
        }

    }
}
