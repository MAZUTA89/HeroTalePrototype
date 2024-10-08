﻿using HTP.Units;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace HTP.Inventories
{
    public class HudCell : Cell
    {
        [SerializeField] private Item _item;

        Player _player;

        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }
        protected override void Start()
        {
            _item.SetPlayer(_player);
            Item = _item;
            base.Start();
            Initialize(_item);
        }

        protected override void OnClick()
        {
            if(_player.Item != null &&
                _player.Item.Id == _item.Id)
            {
                return;
            }
            base.OnClick();
        }

        public override void Initialize(IItemSO item)
        {
            Icon.sprite = _item.Icon;
        }
    }
}
