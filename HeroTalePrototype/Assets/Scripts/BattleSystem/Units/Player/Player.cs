using HTP.Inventories;
using HTP.Machine;
using HTP.Machine.States;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public class Player : Unit
    {
        protected StateMachine StateMachine;
        public Inventory Inventory { get; private set; }
        public ItemHolder ItemHolder { get; private set; }


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

            StateMachine = new StateMachine();

            StateMachine.Initialize(this);

            StateAttack = new AttackState(StateMachine);
            StatePreparation = new BattlePreparationState(StateMachine);

            StateMachine.ChangeState(BattlePreparationState);
        }

        private void Update()
        {
            StateMachine.Update();
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
        public void AnimationAttack()
        {

        }
        public Inventory GetInventory()
        {
            return Inventory;
        }
    }
}
