using HTP.UI;
using HTP.Units;
using System;
using System.Collections.Generic;
using UI.StateUI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HTP.BattleSystem
{
    public class BattleService : MonoBehaviour
    {
        HudUI _hudUI;
        public bool IsBattleHasStarted {  get; private set; }
        public Enemy CurrentEnemy { get; private set; }

        EnemySpawner _enemySpawner;

        Button _startBattleButton;
        Button _leaveBattleButton;
        GameObject _healingObject;

        Player _player;
        UnitInfoUI _enemyInfoUI;

        [Inject]
        public void Construct(HudUI hudUI, EnemySpawner enemySpawner,
            Player player, UnitsInfoUI unitsInfoUI)
        {
            _hudUI = hudUI;
            _startBattleButton = _hudUI.StartBattleButton;
            _leaveBattleButton = _hudUI.LeaveBattleButton;
            _enemySpawner = enemySpawner;
            _player = player;
            _enemyInfoUI = unitsInfoUI.EnemyInfo;
            _healingObject = _hudUI.HealingObject;
        }

        private void Awake()
        {
            IsBattleHasStarted = false;
        }

        private void OnEnable()
        {
            _startBattleButton.onClick.AddListener(OnStartBattle);
            _leaveBattleButton.onClick.AddListener(OnLeaveBattle);
            
        }

        private void OnDisable()
        {
            _startBattleButton.onClick.RemoveListener(OnStartBattle);
            _leaveBattleButton?.onClick.RemoveListener(OnLeaveBattle);
        }

        private void Start()
        {
        }

        void OnStartBattle()
        {
            if(_player.UnitHealth.Health > 5)
            {
                IsBattleHasStarted = true;
                _startBattleButton.gameObject.SetActive(false);
                OnEnemyDead();
                _player.OnStartBattle();
                _leaveBattleButton.gameObject.SetActive(true);
                _healingObject.gameObject.SetActive(false);
            }
        }
        public void OnEndBattle()
        {
            IsBattleHasStarted = false;
            _startBattleButton.gameObject.SetActive(true);
            Destroy(CurrentEnemy.gameObject);
            _enemyInfoUI.gameObject.SetActive(false);
            _healingObject.gameObject.SetActive(true);
            _leaveBattleButton.gameObject.SetActive(false);
        }

        public void OnEnemyDead()
        {
            CurrentEnemy = _enemySpawner.Spawn();
        }

        void OnLeaveBattle()
        {
            _player.OnLeave();
            _leaveBattleButton.gameObject.SetActive(false);
        }


    }
}
