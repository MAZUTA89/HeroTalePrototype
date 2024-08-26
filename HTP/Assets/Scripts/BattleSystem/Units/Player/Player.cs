using HTP.Inventories;
using HTP.Machine;
using HTP.Machine.States;
using UI.StateUI;
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
            UnitStateUI = UnitsInfoUI.PlayerInfo.UnitStateUI;

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
           if(StateMachine.CurrentState is 
                ChangeItemInPreparationState)
            {
                return;
            }
            if(BattleService.IsBattleHasStarted)
            {
                if (item is IWeaponSO)
                {
                    if(StateMachine.CurrentState is BattlePreparationState)
                    {
                        Inventory.RemoveItem(item);
                        HandItem = item;
                        ItemHolder.DeactivateCurrent();
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
                        ItemHolder.DeactivateCurrent();
                        Animator.Play($"take_{HandItem.Id}");
                    }
                    
                }
            }
            else
            {
                Inventory.RemoveItem(item);
                HandItem = item;
                ItemHolder.DeactivateCurrent();
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
        }

        public void ChangeWeapon()
        {
            HandItem = newWeapon;
            ItemHolder.DeactivateCurrent();
            Animator.Play($"take_{HandItem.Id}");
            newWeapon = null;
            IsChangeWeaponInAttackState = false;
        }

        //protected override void OnDead()
        //{
        //    base.OnDead();

        //    OnDeadAnimation();
        //}

    }
}
