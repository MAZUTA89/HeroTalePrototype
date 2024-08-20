using HTP.UI;
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

        EnemySpawner _enemySpawner;

        Button _startBattleButton;

        [Inject]
        public void Construct(HudUI hudUI)
        {
            _hudUI = hudUI;
            _startBattleButton = _hudUI.StartBattleButton;
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

        void OnStartBattle()
        {
            IsBattleHasStarted = true;
            _startBattleButton.gameObject.SetActive(false);
        }

        public void OnEnemyDead()
        {
            _enemySpawner.Spawn();
        }
    }
}
