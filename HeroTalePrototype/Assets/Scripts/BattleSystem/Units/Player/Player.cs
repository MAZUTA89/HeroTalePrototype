﻿using HTP.Inventories;
using HTP.Machine;
using HTP.Machine.States;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public class Player : Unit
    {
        [SerializeField] UnitSO _unitSO;
        public Inventory Inventory { get; private set; }
        public ItemHolder ItemHolder { get; private set; }

        public override IUnitSO UnitSO => _unitSO;

        IWeaponSO _lastWeapon;
        DeadState _deadState;

        [Inject]
        public void ConstructPlayer(Inventory inventory,
            ItemHolder itemHolder)
        {
            Inventory = inventory;
            ItemHolder = itemHolder;
            Inventory.SetPlayer(this);
        }

        protected override void Start()
        {
            base.Start();
            UnitHealth.Initialize(UnitSO, UnitsInfoUI.PlayerInfo);
            UnitsInfoUI.PlayerInfo.NameText.text = UnitSO.Id;
            _deadState = new DeadState(StateMachine);
        }
        protected override void Update()
        {
            base.Update();
            //if(BattleService.IsBattleHasStarted)
            //{
            //    base.Update();
            //}
        }

        public void ActivatePreparationState()
        {
            StateMachine.ChangeState(BattlePreparationState);
        }
        public void ActivateItem()
        {
            if (Item != null)
            {
                ItemHolder.Activate(Item.Id);
            }
        }
        public override void StartAttack()
        {
            if (Item != null)
            { 
               Animator.Play($"attack_{Item.Id}");
            }
        }
        
        public Inventory GetInventory()
        {
            return Inventory;
        }
        public override void SetItem(Item item)
        {
            if(Item != null && Item is IWeaponSO)
            {
                Inventory.AddItem(Item);
                HandItem = null;
            }
            Inventory.RemoveItem(item);
            HandItem = item;

            if(BattleService.IsBattleHasStarted)
            {
                ActivatePreparationState();
            }
        }
        public override void OnDealDamage()
        {
            base.OnDealDamage();

            if(Item is IWeaponSO weapon)
            {
                BattleService.CurrentEnemy.TakeDamage(GetDamage(weapon.Damage));
            }
        }
        public override void OnDeadAnimation()
        {
            BattleService.OnEndBattle();
            StateMachine.ChangeState(_deadState);
        }

        public void OnStartBattle()
        {
            StateMachine.ChangeState(BattlePreparationState);
        }

        public void OnLeave()
        {
            OnDeadAnimation();
        }

    }
}
