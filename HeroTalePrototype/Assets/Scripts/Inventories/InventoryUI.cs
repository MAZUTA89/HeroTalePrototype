using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HTP.Inventories
{
    public class InventoryUI : MonoBehaviour
    {
        Inventory _inventory;
        List<Cell> _cells;

        public int Size => _cells.Count;

        private void Awake()
        {
            _cells = new List<Cell>();
            foreach (Transform obj in transform)
            {
                if (obj.TryGetComponent(out Cell cell))
                {
                    _cells.Add(cell);
                }
            }
        }
        private void Start()
        {
        }
        public void UpdateUI(List<Item> items)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                if (i < items.Count)
                {
                    _cells[i].gameObject.SetActive(true); 
                    _cells[i].Initialize(items[i]);

                }
                else
                {
                    _cells[i].gameObject.SetActive(false);
                }
            }
        }
        public int GetSize()
        {
            return _cells.Count;
        }
    }
}
