using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamingManuPanel : GUIBase<GamingManuPanel>
{
    public Texture backgroundTexture;
    private bool isQuitWindowOpen = false;

    private float screenWidth = Screen.width;
    private float screenHight = Screen.height;
    
    //可使用快捷键ESC来开关菜单
    private void Update()
    {
        screenWidth = Screen.width;
        screenHight = Screen.height;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ifActive = !ifActive;
            if (ifActive)
            {
                Show();
                //解锁鼠标指针
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                //锁定鼠标指针
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
    }

    private void OnGUI()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PortfolioBrowserFont.Apply();
#endif
        if(!ifActive)
        {
            return;
        }

        GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHight), backgroundTexture);
        if (GUI.Button(new Rect(screenWidth / 2 - 50, screenHight / 2 - 100, 100, 30), "继续游戏"))
        {
            ifActive = false;
            Time.timeScale = 1;
        }
        if (GUI.Button(new Rect(screenWidth / 2 - 50, screenHight / 2 - 50, 100, 30), "设置"))
        {
            SettingPanel.Show(); 
            ifActive = false;      
        }
        if (GUI.Button(new Rect(screenWidth / 2 - 50, screenHight / 2, 100, 30), "返回主菜单"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        }
        if (GUI.Button(new Rect(screenWidth / 2 - 50, screenHight / 2 +50, 100, 30), "退出游戏"))
        {
            isQuitWindowOpen = true;
        }
        if (isQuitWindowOpen)
        {
            GUI.Window(0, new Rect(screenWidth / 2 - 100, screenHight / 2 - 50, 200, 100), QuitGameWindow, "退出游戏");
        }
    }

    public static void ShowThis()
    {
        instance.ifActive = true;
        Show();
        Time.timeScale = 0;
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
