using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //传入武器预设体，作为该收集物的武器池，随机获取一个装载
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //随机选择加强属性，直接传入索引，由玩家坦克处理
            int i = Random.Range(0,5);
            other.gameObject.GetComponent<PlayerTank>().GetStatsBuff(i);              
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        gameObject.transform.Rotate(Vector3.up*Time.deltaTime*50);
    }
}
