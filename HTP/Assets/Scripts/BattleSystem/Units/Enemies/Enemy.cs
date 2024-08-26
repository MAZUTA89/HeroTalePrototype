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
            _enemyInfoUI = UnitsInfoUI.EnemyInfo;
            UnitStateUI = _enemyInfoUI.UnitStateUI;

            HandItem = _enemyUnitSO.Weapon;

            base.Start();
            UnitHealth.Initialize(UnitSO, UnitsInfoUI.EnemyInfo);
            
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
            if(Item is WeaponSO weapon)
            {
                Player.TakeDamage(GetDamage(weapon.Damage));
            }
            if (Player.UnitHealth.IsAlive == false)
            {
                _enemyInfoUI.gameObject.SetActive(false);
                UnitStateUI.gameObject.SetActive(false);
            }
        }

        public override void OnDeadAnimation()
        {
            base.OnDeadAnimation();

            BattleService.OnEnemyDead();
        }


        protected override void OnDead()
        {
            base.OnDead();
            
        }

    }
}
