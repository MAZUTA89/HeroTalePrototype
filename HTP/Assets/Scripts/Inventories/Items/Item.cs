using HTP.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HTP.Inventories
{
    public abstract class Item : ScriptableObject, IItemSO
    {
        [SerializeField] private string _id;
        [SerializeField] private string _displayId;
        [SerializeField] private Sprite _icon;
        
        public string Id => _id;

        public string DisplayId => _displayId;

        public Sprite Icon => _icon;

        protected Player Player;

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public abstract void Apply();

        public abstract bool ApplyCondition();
    }
}
