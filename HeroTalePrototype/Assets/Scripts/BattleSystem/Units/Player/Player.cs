using HTP.Inventories;
using HTP.Machine;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public class Player : Unit
    {
        public Inventory Inventory { get; private set; }
        public ItemHolder ItemHolder { get; private set; }
        IWeaponSO _lastWeapon;
        Enemy _enemy;

        [Inject]
        public void ConstructPlayer(Inventory inventory,
            ItemHolder itemHolder, Enemy enemy)
        {
            Inventory = inventory;
            ItemHolder = itemHolder;
            Inventory.SetPlayer(this);
            _enemy = enemy;
        }

        protected override void Start()
        {
            base.Start();
            UnitHealth.Initialize(UnitSO, UnitsInfoUI.PlayerInfo);
            UnitsInfoUI.PlayerInfo.NameText.text = UnitSO.Id;
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
            ActivatePreparationState();
        }
        public override void OnDealDamage()
        {
            base.OnDealDamage();

            if(Item is IWeaponSO weapon)
            {
                _enemy.TakeDamage(GetDamage(weapon.Damage));
            }
        }
    }
}
