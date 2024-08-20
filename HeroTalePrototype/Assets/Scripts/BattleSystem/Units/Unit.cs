using HTP.BattleSystem;
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
        public abstract IUnitSO UnitSO { get; }
        public StateUI StateUI => _stateUI;

        public Item Item => HandItem;

        public IUnitState BattlePreparationState => StatePreparation;

        public IUnitState AttackState => StateAttack;
        protected Item HandItem;
        protected IUnitState StatePreparation;
        protected IUnitState StateAttack;
        protected StateMachine StateMachine;

        Animator _animator;
        protected UnitsInfoUI UnitsInfoUI;
        public UnitHealth UnitHealth;
        protected BattleService BattleService;
        [Inject]
        public void Construct(UnitsInfoUI unitsInfoUI,
            BattleService battleService)
        {
            UnitsInfoUI = unitsInfoUI;
            BattleService = battleService;
        }
        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();

            StateMachine = new StateMachine();

            StateMachine.Initialize(this);

            StateAttack = new AttackState(StateMachine);
            StatePreparation = new BattlePreparationState(StateMachine);

            UnitHealth = new UnitHealth();

            StartPrepare();
        }

        protected virtual void OnDisable()
        {
        }
        protected virtual void Update()
        {
            
            //if (BattleService.IsBattleHasStarted)
            //{
                StateMachine.Update();
            //}
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
            if (UnitHealth.IsAlive == false)
            {
                OnDead();
            }
        }

        protected float GetDamage(float itemDamage)
        {
            return itemDamage * Mathf.Sqrt(UnitSO.Strength);
        }
        protected virtual void OnDead()
        {
            Animator.SetTrigger("dead");
        }
        public virtual void OnDeadAnimation()
        {
            Destroy(gameObject);
        }


    }
}
