using HTP.Inventories;
using HTP.Machine;
using HTP.Machine.States;
using System;
using System.Collections.Generic;
using UI.StateUI;
using UnityEngine;
using Zenject;

namespace HTP.Units
{
    public abstract class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private StateUI _stateUI;

        public Animator Animator => _animator;
        public IUnitSO UnitSO => UnitData;
        public StateUI StateUI => _stateUI;

        public Item Item => HandItem;

        public IUnitState BattlePreparationState => StatePreparation;

        public IUnitState AttackState => StateAttack;
        protected Item HandItem;
        protected IUnitState StatePreparation;
        protected IUnitState StateAttack;
        protected StateMachine StateMachine;

        Animator _animator;
        protected IUnitSO UnitData;
        protected UnitsInfoUI UnitsInfoUI;
        public UnitHealth UnitHealth;

        [Inject]
        public void Construct(UnitSO unitSO, UnitsInfoUI unitsInfoUI)
        {
            UnitData = unitSO;
            UnitsInfoUI = unitsInfoUI;
        }
        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();

            StateMachine = new StateMachine();

            StateMachine.Initialize(this);

            StateAttack = new AttackState(StateMachine);
            StatePreparation = new BattlePreparationState(StateMachine);

            StateMachine.ChangeState(BattlePreparationState);

            UnitHealth = new UnitHealth();
        }
        
        protected virtual void OnDisable()
        {
        }
        protected virtual void Update()
        {
            StateMachine.Update();
        }

        public virtual void StartAttack()
        {
            Animator.SetTrigger("attack");
        }

        public virtual void StartPrepare()
        {
            Animator.SetTrigger("idle");
        }
        public virtual void SetItem(Item item)
        {
            HandItem = item;
        }
        public virtual void OnDealDamage()
        {
            //Animator.Play("get_damage");
        }
        public virtual void TakeDamage(float damage)
        {
            UnitHealth.TakeDamage(damage / 
                Mathf.Sqrt(UnitSO.Armor));
            Animator.SetTrigger("get_damage");
        }

        protected float GetDamage(float itemDamage)
        {
            return itemDamage * Mathf.Sqrt(UnitSO.Strength);
        }
    }
}
