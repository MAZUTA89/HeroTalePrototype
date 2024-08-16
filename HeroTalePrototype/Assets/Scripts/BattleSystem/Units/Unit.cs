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

        public IWeaponSO WeaponSO => Weapon;

        public IUnitState BattlePreparationState => StatePreparation;

        public IUnitState AttackState => StateAttack;
        protected IWeaponSO Weapon;
        protected IUnitState StatePreparation;
        protected IUnitState StateAttack;

        Animator _animator;
        IUnitSO _unitSO;
        [Inject]
        public void Construct(IUnitSO unitSO)
        {
            _unitSO = unitSO;
        }
        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public abstract void StartAttack();

        public abstract void StartPrepare();
    }
}
