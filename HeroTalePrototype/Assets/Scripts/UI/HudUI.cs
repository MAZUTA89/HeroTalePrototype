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
