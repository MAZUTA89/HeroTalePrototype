using HTP.UI;
using HTP.Units;
using System;
using System.Collections.Generic;
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

        Player _player;

        [Inject]
        public void Construct(HudUI hudUI, EnemySpawner enemySpawner,
            Player player)
        {
            _hudUI = hudUI;
            _startBattleButton = _hudUI.StartBattleButton;
            _enemySpawner = enemySpawner;
            _player = player;
        }

        private void Awake()
        {
            IsBattleHasStarted = false;
        }

        private void OnEnable()
        {
            _startBattleButton.onClick.AddListener(OnStartBattle);
        }

        private void OnDisable()
        {
            _startBattleButton.onClick?.RemoveListener(OnStartBattle);
        }

        private void Start()
        {
            OnEnemyDead();
        }

        void OnStartBattle()
        {
            if(_player.UnitHealth.Health > 5)
            {
                IsBattleHasStarted = true;
                _startBattleButton.gameObject.SetActive(false);
            }
        }
        public void OnEndBattle()
        {
            IsBattleHasStarted = false;
            _startBattleButton.gameObject.SetActive(true);
        }

        public void OnEnemyDead()
        {
            CurrentEnemy = _enemySpawner.Spawn();
        }
    }
}
