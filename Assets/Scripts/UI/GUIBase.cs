using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//特性用于不开启项目调试位置显示
[ExecuteAlways]
public class GUIBase<T> : MonoBehaviour
{
    public static GUIBase<T> instance;
    public bool ifActive = true;

    void Awake()
    {
        //类型转换为子类类型
        instance = this as GUIBase<T>;
    }



    public static void Hide()
    {
        instance.gameObject.SetActive(false);
    }
    public static void Show()
    {
        instance.gameObject.SetActive(true);
    }}
