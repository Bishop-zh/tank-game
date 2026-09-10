using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollection : MonoBehaviour
{
    private float time = 0;

    //为结束点加一些动态效果
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.Rotate(Time.deltaTime*10,Time.deltaTime*10,Time.deltaTime*10,Space.World);
        gameObject.transform.Translate(0,Mathf.Sin(time)*0.01f,0,Space.World);
    
    }


    //结束点设置为触发器，玩家坦克接触后通关，显示通关界面耗时，记录排行榜分数
    void OnTriggerEnter(Collider other)
    {
        EndGamePanel.ShowThis();
        Cursor.lockState = CursorLockMode.None;
    }
}
