using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Inventories
{
    public interface IItemSO
    {
        string Id { get; }
        string DisplayId { get; }
        Sprite Icon { get; }
        void Apply();
        bool ApplyCondition();
    }
}
