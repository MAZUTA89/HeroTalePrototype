using System;
using System.Collections.Generic;
using UI.StateUI;
using UnityEngine;
using Zenject;

namespace HTP
{
    public class AlignWithScreenPoint : MonoBehaviour
    {
        public AlignType AlignType;
        private RectTransform ScreenPoint;

        Camera _camera;

        UnitsInfoUI _itsInfoUI;
        [Inject]
        public void Construct(UnitsInfoUI unitsInfoUI)
        {
            _itsInfoUI = unitsInfoUI;
        }
        private void Start()
        {
            _camera = Camera.main;

            if(AlignType.Player == AlignType)
            {
                ScreenPoint = _itsInfoUI.PlayerInfo.UnitScreenPosition;
            }
            else
                ScreenPoint = _itsInfoUI.EnemyInfo.UnitScreenPosition;

            Align();
        }

        void Align()
        {
            // Получаем позицию элемента в экранных координатах
            Vector3 screenPos = _camera.WorldToScreenPoint(ScreenPoint.position);

            // Преобразуем экранные координаты в мировые координаты
            Vector3 worldPos = _camera.ScreenToWorldPoint(screenPos);

            // Для 2D игр, вероятно, вам нужно будет сбросить Z координату
            //worldPos.z = 0f;
            //Vector3 worldPos = _camera.ScreenToWorldPoint(ScreenPoint.position);
            worldPos.z = 0;
            transform.position = worldPos;
        }
    }

    public enum AlignType
    {
        Player,
        Enemy
    }
}
