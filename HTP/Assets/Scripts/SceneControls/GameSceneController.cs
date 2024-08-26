using HTP.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace HTP.SceneControls
{
    public class GameSceneController : MonoBehaviour
    {
        Button _exitButton;

        [Inject]
        public void Construct(HudUI hudUI)
        {
            _exitButton = hudUI.ExitButton;
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(OnExit);
        }
        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(OnExit);
        }

        void OnExit()
        {
            SceneManager.LoadScene(GameConfig.s_MenuSceneName);
        }
    }
}
