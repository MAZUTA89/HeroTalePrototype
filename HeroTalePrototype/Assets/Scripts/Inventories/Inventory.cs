using HTP.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HTP.Inventories
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> _startItems;
        public int Size { get; private set; }
        public List<Item> Items => _startItems;
        Player _player;
        InventoryUI _inventoryUI;

        [Inject]
        public void Construct(
            InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }
        
        private void Start()
        {
            _inventoryUI.UpdateUI(Items);
            Size = _inventoryUI.GetSize();
            foreach (Item item in Items)
            {
                item.SetPlayer(_player);
            }
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
            _inventoryUI.UpdateUI(Items);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
            _inventoryUI.UpdateUI(Items);
        }
        public void SetPlayer(Player player)
        {
            _player = player;
        }
    }
}
