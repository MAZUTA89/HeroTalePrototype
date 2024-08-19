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
        public TextMeshProUGUI NameText => _nameText;
        public Slider HealthSlider => _healthSlider;

        float _healthValue;

        public void SetHealthValue(float healthValue)
        {
            _healthValue = healthValue;
        }

        private void Update()
        {
            HealthSlider.value = Mathf.Lerp(HealthSlider.value,
                _healthValue, Time.deltaTime * c_healthValueSpeed);
        }

    }
}
