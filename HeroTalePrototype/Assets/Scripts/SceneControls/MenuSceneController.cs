using HTP.SceneControls;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HTP.Menu
{
    public class MenuSceneController : MonoBehaviour
    {
        private void Start()
        {
            
        }
        public void OnStart()
        {
            SceneManager.LoadScene(GameConfig.s_GameSceneName);
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}