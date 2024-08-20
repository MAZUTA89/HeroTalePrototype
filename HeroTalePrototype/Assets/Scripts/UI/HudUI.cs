using HTP.Inventories;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HTP.UI
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField] Button _openInventoryButton;
        [SerializeField] Button _startBattleButton;
        [SerializeField] Button _leaveBattleButton;
        [SerializeField] GameObject _healingButton;

        public Button OpenInventoryButton => _openInventoryButton;
        public Button StartBattleButton => _startBattleButton;
        public Button LeaveBattleButton => _leaveBattleButton;
        public GameObject HealingObject => _healingButton;

        InventoryUI _inventoryUI;

        [Inject]
        public void Construct(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }

        private void OnEnable()
        {
            _openInventoryButton.onClick.AddListener(OnOpenInventory);
        }

        private void OnDisable()
        {
            _openInventoryButton.onClick.RemoveListener(OnOpenInventory);
        }
        private void Start()
        {
            StartBattleButton.gameObject.SetActive(true);
            LeaveBattleButton.gameObject.SetActive(false);
        }

        void OnOpenInventory()
        {
            if(_inventoryUI.gameObject.activeSelf)
            {
                _inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                _inventoryUI.gameObject.SetActive(true);
            }
        }
    }
}
