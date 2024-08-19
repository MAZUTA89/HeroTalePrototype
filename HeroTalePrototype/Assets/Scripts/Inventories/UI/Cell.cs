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
        [SerializeField] private Image Icon;
        [SerializeField] private TextMeshProUGUI _itemText;

        IItemSO _item;

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

        public void Initialize(IItemSO item)
        {
            _item = item;
            Icon.sprite = _item.Icon;
            _itemText.text = _item.DisplayId;
        }

        void OnClick()
        {
            if(_item.ApplyCondition())
            {
                _item.Apply();
            }
        }
        
    }
}
