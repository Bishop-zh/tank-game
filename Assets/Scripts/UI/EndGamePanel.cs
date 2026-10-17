using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManager使用的命名空间
using UnityEngine.SceneManagement;

public class EndGamePanel : GUIBase<EndGamePanel>
{
    public Texture backgroundTexture;
    //默认不显示结束界面
    private bool isQuitWindowOpen = false;

    private float screenWidth = Screen.width;
    private float screenHight = Screen.height;
    
    
    private void Update()
    {
        screenWidth = Screen.width;
        screenHight = Screen.height;        
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

        GUI.DrawTexture(new Rect(screenWidth/4, screenWidth/4, screenWidth/2, screenHight/2), backgroundTexture);
        if (GUI.Button(new Rect(screenWidth / 2 - 50, screenHight / 2 - 50, 100, 30), "重新开始"))
        {
            ifActive = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
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
