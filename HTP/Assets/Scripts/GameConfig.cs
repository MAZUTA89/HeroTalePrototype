using System;
using System.Collections.Generic;


namespace HTP.SceneControls
{
    public static class GameConfig
    {
        public static readonly string s_GameSceneName;
        public static readonly string s_MenuSceneName;
        static GameConfig()
        {
            s_GameSceneName = "GameScene";
            s_MenuSceneName = "MenuScene";
        }
    }
}
