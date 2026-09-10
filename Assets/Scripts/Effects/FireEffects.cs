using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffects : MonoBehaviour
{
    //特效预设体数组，按顺序对应不同的特效类型
    public GameObject[] effectPrefabs;
    //生成特效位置，与上方特效预设体一一按顺序对应
    public Transform[] effectTransforms;

    //子弹或其他武器产生时候生成特效
    void OnEnable()
    {
        //未定义特效位置则生成在原地位置
        for(int i = 0; i<effectPrefabs.Length; i++)
        {
            
            if(effectTransforms[i] == null)
            {
                GameObject effects = Instantiate(effectPrefabs[i],transform.position,transform.rotation);
                Destroy(effects, 0.5f);
            }
            else
            {
                GameObject effects = Instantiate(effectPrefabs[i],effectTransforms[i].position,effectTransforms[i].rotation);
                Destroy(effects, 0.5f);
            }            
        }
       
    }
}
