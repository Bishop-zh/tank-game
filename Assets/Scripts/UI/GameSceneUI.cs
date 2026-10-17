using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameSceneUI : GUIBase<GameSceneUI>
{
    public Rect hpRect = new Rect(50,Screen.height-100,300,50);
    public Texture hpBackGroundTexture;
    public Texture hpTexture;
    public GUIStyle hpStyle;

    public Rect scoreTipRect;
    public GUIStyle scoreTipStyle;
    public Rect scoreRect;
    public GUIStyle scoreStyle;
    private static float score = 0;
    
    public static String ststsChangeTip;
    

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
        PortfolioBrowserFont.Apply(hpStyle,scoreTipStyle,scoreStyle);
#endif
        // //放到角色类中渲染，便于读取角色血量
        // //绘制血量以及血量底图（血量显示尝试进一步优化为可按血量分格显示）
        // GUI.DrawTexture(new Rect(50, screenHight - 100, 300, 50), hpBackGroundTexture);
        // //设置血条颜色
        // GUI.color = Color.red;
        // //根据玩家血量百分比动态计算血条长度
        // GUI.DrawTexture(new Rect(57, screenHight - 90, 285 * 0.6f, 35), hpTexture);
        // GUI.color = Color.white;
        // GUI.Label(new Rect(50, screenHight - 50, 300, 50), "获取主角血量", hpStyle);

        //绘制角色头像（武器变化也要跟着变化）（使用正面一个独立摄像头实现？，并且过滤其他对象,每次武器更新后调用一次更新来优化性能）
        //占位
        //

        //显示分数，分数从游戏逻辑类获取
        GUI.Label(new Rect(screenWidth/2 - 60, 10, 140, 30), "分数", scoreTipStyle);
        GUI.Label(new Rect(screenWidth/2 - 100, 40, 140, 30), score.ToString("F0"), scoreStyle);

        //显示当前游戏消耗时间

        String nowTime = Time.time.ToString("F2") + "s";
        GUI.Label(new Rect(100, 10, 140, 30), "时间", scoreStyle);
        GUI.Label(new Rect(100, 40, 140, 30), nowTime, scoreStyle);

        //显示拾取道具后属性变化
        GUI.Label(new Rect(screenWidth/3*2, screenHight/2, 140, 30), ststsChangeTip, scoreStyle);
        
        //子弹冷却显示
        //已在WeaponBase中实现
        //


        //技能状态显示（释放技能快捷键，冷却时间读条直观显示，数字提示并且在技能冷却中释放一个遮罩层，修改遮罩大小来体现冷却进度。性能优化：减少刷新频率？如何减少）
        //武器冷却按照这个模式来实现，每帧进行渲染
        //
        

        //房间小地图，地图设计上动态生成房间，类似于元气骑士，以撒的房间内容，独立的渲染房间布局，只表示房间大小以及房间类型，房间内剩余屋子，房间样式不表示，使用代码生成，不创建独立相机）
        //独立摄像机，每个物体带有一个单独的2D层级，这个摄像机只看到该层级图像，主摄像机看不到。
        //
    }     
    
    //外部调用设置显示内容
    public static void UpdateTip(string newTip)
        {
            ststsChangeTip = newTip;
        }

    public static void AddScore(float addedScore)
    {
        score += addedScore;
    }
    
    public static void SubScore(float subedScore)
    {
        score -= subedScore;
    }


}

