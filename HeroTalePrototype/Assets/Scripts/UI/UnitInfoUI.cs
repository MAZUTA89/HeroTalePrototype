using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
namespace UI.StateUI
{
    public class UnitInfoUI : MonoBehaviour
    {
        const float c_healthValueSpeed = 100f;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private StateUI _unitStateUI;
        [SerializeField] private Image _unitScreenPosition;
        public TextMeshProUGUI NameText => _nameText;
        public Slider HealthSlider => _healthSlider;
        public StateUI UnitStateUI => _unitStateUI;

        public RectTransform UnitScreenPosition => _unitScreenPosition.rectTransform;

        float _healthValue;

        public void SetHealthValue(float healthValue)
        {
            _healthValue = healthValue;
        }

        private void Start()
        {
            _unitScreenPosition.gameObject.SetActive(false);
        }

        private void Update()
        {
            HealthSlider.value = Mathf.Lerp(HealthSlider.value,
                _healthValue, Time.deltaTime * c_healthValueSpeed);
        }

    }
}
