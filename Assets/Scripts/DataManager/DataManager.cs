using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    //处理音量音效的存储
    public static float GetBackMusicVolume()
    {
        return PlayerPrefs.GetFloat("BackMusicVolume",0.6f);
    }
    public static float GetEffectMusicVolume()
    {
        return PlayerPrefs.GetFloat("EffectMusicVolume",0.6f);
    }
    public static void SaveBackMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("BackMusicVolume", volume);
    }
    public static void SaveEffectMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("EffectMusicVolume", volume);
    }

    //处理排行榜数据存储
    public static void SaveScore(float score,string name)
    {
        PlayerPrefs.SetFloat(name,score);
    }
    //public static string[] GetScore(string name)
    //{
        //string[] rank = PlayerPrefs.GetString(name);
       // return rank;
    //}
}
    

