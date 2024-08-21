using HTP.Units;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HTP.Inventories
{
    [RequireComponent(typeof(Button))]
    public class Cell : MonoBehaviour
    {
        Button _button;
        [SerializeField] protected Image Icon;
        [SerializeField] private TextMeshProUGUI _itemText;

        protected IItemSO Item;

        private void OnEnable()
        {
        }
        private void OnDisable()
        {
            
        }
        protected virtual void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public virtual void Initialize(IItemSO item)
        {
            Item = item;
            Icon.sprite = Item.Icon;
            _itemText.text = Item.DisplayId;
        }

        protected virtual void OnClick()
        {
            if(Item.ApplyCondition())
            {
                Item.Apply();
            }
        }
        
    }
}
