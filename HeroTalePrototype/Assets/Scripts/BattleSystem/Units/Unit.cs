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
        public IUnitSO UnitSO => _unitSO;
        public StateUI StateUI => _stateUI;

        public Item Item => HandItem;

        public IUnitState BattlePreparationState => StatePreparation;

        public IUnitState AttackState => StateAttack;
        protected Item HandItem;
        protected IUnitState StatePreparation;
        protected IUnitState StateAttack;

        Animator _animator;
        IUnitSO _unitSO;
        [Inject]
        public void Construct(UnitSO unitSO)
        {
            _unitSO = unitSO;
        }
        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public virtual void StartAttack()
        {
            Animator.SetTrigger("attack");
        }

        public virtual void StartPrepare()
        {
            Animator.SetTrigger("idle");
        }
        public void SetItem(Item item)
        {
            HandItem = item;
        }
    }
}
