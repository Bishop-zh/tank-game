using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : GUIBase<StartPanel>
{
    public Rect startGameButtonRect;
    public GUIStyle startGameButtonStyle;

    public Rect settingButtonRect;
    public GUIStyle settingButtonStyle;

    public Rect quitButtonRect;
    public GUIStyle quitButtonStyle;

    private float screenWidth = Screen.width;
    private float screenHight = Screen.height;

    private bool isQuitWindowOpen = false;

    private void Update()
    {
        screenWidth = Screen.width;
        screenHight = Screen.height;
    }

    //开始界面ui以及交互逻辑
    private void OnGUI()
    {
        if (GUI.Button(new Rect(screenWidth / 2 - 80, screenHight / 2 - 50, 150, 50), "开始游戏", startGameButtonStyle))
        {
            SceneManager.LoadScene("GameScene");
            Hide();
        }
        if (GUI.Button(new Rect(screenWidth / 2 - 80, screenHight / 2 + 20, 150, 50), "设置", settingButtonStyle))
        {
            SettingPanel.Show();
            Hide();
        }
        if (GUI.Button(new Rect(screenWidth / 2 - 80, screenHight / 2 + 90, 150, 50), "退出游戏", quitButtonStyle))
        {
            isQuitWindowOpen = true;
        }
        if (isQuitWindowOpen)
        {
            GUI.Window(0, new Rect(screenWidth / 2 - 100, screenHight / 2 - 50, 200, 100), QuitGameWindow, "退出游戏");
        }
    }



    private void QuitGameWindow(int windowID)
    {
        if (GUI.Button(new Rect(20, 40, 60, 30), "确认"))
        {
            Application.Quit();
        }
        if (GUI.Button(new Rect(120, 40, 60, 30), "取消"))
        {
            isQuitWindowOpen = false;
        }
    }
}
