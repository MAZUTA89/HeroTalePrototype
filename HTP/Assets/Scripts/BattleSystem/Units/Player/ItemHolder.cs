using System;
using System.Collections.Generic;
using UnityEngine;

namespace HTP.Units
{
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _handObjects;
        GameObject _current;
        public void Activate(string itemId)
        {
            foreach (GameObject obj in _handObjects)
            {
                if (obj.name == itemId)
                {
                    obj.SetActive(true);
                    _current = obj;
                }
                else
                {
                    obj.SetActive(false);
                }
            }
        }
        public void DeactivateCurrent()
        {
            if(_current != null)
            {
                _current.gameObject.SetActive(false);
            }
        }
    }
}
