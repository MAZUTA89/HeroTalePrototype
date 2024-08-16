using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StateUI
{
    public class StateUI : MonoBehaviour
    {
        [SerializeField] Image _timerImage;
        [SerializeField] GameObject _preparationIcon;
        [SerializeField] GameObject _attackIcon;
        public Image TimerImage => _timerImage;
        public GameObject PreparationIcon => _preparationIcon;
        public GameObject AttackIcon => _attackIcon;
    }
}

