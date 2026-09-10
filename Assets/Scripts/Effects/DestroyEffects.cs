using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffects : MonoBehaviour
{
    public GameObject[] effectPrefabs;
    //生成特效位置，与上方特效预设体一一按顺序对应，并且数组长度要和预设体一致，不使用可为空
    public Transform[] effectTransforms;

    void OnDestroy()
    {
        
        for(int i = 0; i<effectPrefabs.Length; i++)
        {
            //未设定位置就在该对象原地产生,三秒后销毁特效
            if(effectTransforms[i] == null)
            {
                GameObject effects = Instantiate(effectPrefabs[i],transform.position,transform.rotation);
                Destroy(effects, 3f);
            }
            else
            {
                GameObject effects = Instantiate(effectPrefabs[i],effectTransforms[i].position,effectTransforms[i].rotation);
                Destroy(effects, 3f);
            }            
        }
       
    }
}
