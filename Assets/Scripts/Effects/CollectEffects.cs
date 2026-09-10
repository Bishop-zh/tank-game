using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffects : MonoBehaviour
{
    //特效预设体数组，按顺序对应不同的特效类型
    public GameObject[] effectPrefabs;
    //生成特效位置，与上方特效预设体一一按顺序对应
    public Transform[] effectTransforms;

    //拾取掉落物时候在角色身上生成特效
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i<effectPrefabs.Length; i++)
            {
                
                if(effectTransforms[i] == null)
                {
                    GameObject effects = Instantiate(effectPrefabs[i],other.transform.position,other.transform.rotation);
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
}
