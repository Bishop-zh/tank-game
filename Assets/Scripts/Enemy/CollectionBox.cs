using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBox : TankBase
{
    public GameObject[] collections; //存放可产生的掉落物    
    public float percent = 50f; // 产生掉落物概率

    //继承子类wound方法，便于使用父类容器装载子类，方便其他方法的实现
    public override void  Wound(float finalAtk)
    {
        float takeDamage = finalAtk - defent;
        if(takeDamage <= 0)
        {
            return;
        }
        hp -= takeDamage;
        if (hp <= 0)
        {
            //按照生成概率判断是否在当前位置独立随机创建奖励品对象
            if (Random.value * 100 < percent)
            {
                GameObject collection = Instantiate(collections[Random.Range(0,collections.Length)],transform.position,transform.rotation);
            }
            Death();
        }
    }

    public override void Death()
    {
        GameSceneUI.AddScore(10);
        base.Death();
    }
        
}
