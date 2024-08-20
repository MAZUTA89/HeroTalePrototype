using HTP.Inventories;
using HTP.Machine;
using HTP.Machine.States;
using Unity.VisualScripting;
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
        public ChangeItemInPreparationState ChangeItemInPreparationState { get; private set; }
        public ChangeItemInAttackState ChangeItemInAttackState { get; private set; }
        public bool IsChangeWeaponInAttackState {  get; private set; }
        Item newWeapon;

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
            ChangeItemInPreparationState = 
                new ChangeItemInPreparationState(StateMachine);
            ChangeItemInAttackState =
                new ChangeItemInAttackState(StateMachine);
            StateAttack = new PlayerAttackState(StateMachine);
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
                //HandItem = null;
            }
           
            if(BattleService.IsBattleHasStarted)
            {
                if (item is IWeaponSO)
                {
                    if(StateMachine.CurrentState is BattlePreparationState)
                    {
                        Inventory.RemoveItem(item);
                        HandItem = item;
                        Animator.Play($"take_{HandItem.Id}");
                        StateMachine.ChangeState(ChangeItemInPreparationState);
                    }
                    else if(StateMachine.CurrentState is AttackState)
                    {
                        IsChangeWeaponInAttackState = true;
                        Inventory.RemoveItem(item);
                        newWeapon = item;
                    }
                    else
                    {
                        Inventory.RemoveItem(item);
                        HandItem = item;
                        Animator.Play($"take_{HandItem.Id}");
                    }
                    
                }
                //StateMachine.WaitAndAction(2, ActivatePreparationState);
                //ActivatePreparationState();
            }
            else
            {
                Inventory.RemoveItem(item);
                HandItem = item;
                Animator.Play($"take_{HandItem.Id}");
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

        public void OnEndAttackAnimation()
        {
            //if (IsChangeWeaponInAttackState)
            //{
            //    HandItem = newWeapon;
            //    StateMachine.ChangeState(_changeItemInAttackState);
            //    IsChangeWeaponInAttackState  = false;
            //}
        }

        public void ChangeWeapon()
        {
            HandItem = newWeapon;
            Animator.Play($"take_{HandItem.Id}");
            newWeapon = null;
            IsChangeWeaponInAttackState = false;
        }

    }
}
