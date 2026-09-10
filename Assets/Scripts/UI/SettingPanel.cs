using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : GUIBase<SettingPanel>
{
    public Rect backMuiscToggleRect;
    public bool backMusicToggleState = true;

    public Rect effectMusicToggleRect;
    public bool effectMusicToggleState = true;

    public Rect backMusicVolumeSliderRect;
    public float backMusicVolume;

    public Rect effectMusicVolumeSliderRect;
    public float effectMusicVolume;

    public Rect quitBUttonRect;
    public GUIStyle quitButtonStyle;

    public Rect tripLabelRect;
    public Rect backTextureRect;
    public Texture backTexture;

    private float screenWidth = Screen.width;
    private float screenHight = Screen.height;

    public void Awake()
    {
        instance = this;
        Hide();

        if (Application.isPlaying)
            DontDestroyOnLoad(gameObject);
    }
    public void OnEnable()
    {
        backMusicVolume = DataManager.GetBackMusicVolume();
        effectMusicVolume = DataManager.GetEffectMusicVolume();
    }

    private void Update()
    {
        screenWidth = Screen.width;
        screenHight = Screen.height;
        backTextureRect = new Rect(screenWidth/3, screenHight/3, screenWidth/3, screenHight/3);
    }
    
    public void OnDisable()
    {
        DataManager.SaveBackMusicVolume(backMusicVolume);
        DataManager.SaveEffectMusicVolume(effectMusicVolume);
    }

    private void OnGUI()
    {
        GUI.DrawTexture(backTextureRect, backTexture);
        GUI.Label(new Rect(backTextureRect.x+screenWidth/6, backTextureRect.y + 20, backTextureRect.width/2, 30), "设置");

        //利用多选框制作开启关闭按钮
        backMusicToggleState = GUI.Toggle(new Rect(backTextureRect.x + 80, backTextureRect.y + 60, 200, 30), backMusicToggleState, "背景音乐");
        effectMusicToggleState = GUI.Toggle(new Rect(backTextureRect.x + 80, backTextureRect.y + 100, 200, 30), effectMusicToggleState, "游戏音效");

        //利用slider制作音量音效调节条
        backMusicVolume = GUI.HorizontalSlider(new Rect(backTextureRect.x + 240, backTextureRect.y + 60, 200, 30), backMusicVolume, 0, 1);
        effectMusicVolume = GUI.HorizontalSlider(new Rect(backTextureRect.x + 240, backTextureRect.y + 100, 200, 30), effectMusicVolume, 0, 1);

        if (GUI.Button(new Rect(backTextureRect.x + screenWidth/3 -80, backTextureRect.y + 10, 80, 80), "", quitButtonStyle))
        {
            if(SceneManager.GetActiveScene().name == "BeginScene")
            {
                StartPanel.Show();
                Hide();
            }
            else if(SceneManager.GetActiveScene().name == "GameScene")
            {
                GamingManuPanel.ShowThis();
                Hide();
            }
            else
                Debug.LogError("SettingPanel:当前场景不在StartScene和GameScene中");
            
        }
      
    }
}
