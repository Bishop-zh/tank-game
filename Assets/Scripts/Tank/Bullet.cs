using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float durationTime = 5000f;
    GameObject owner;

    public float bulletBaseSpeed;
    private float nowTime;
    
    //子弹最终伤害
    private float bulletDamage;

    void Awake()
    {
        nowTime = Time.time;
    }

    void Update()
    {
        if(Time.time > nowTime+durationTime)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward*bulletBaseSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        //防止子弹在产生时与发射子弹对象和其他子弹发生碰撞，导致无法发射
        if (other.gameObject != owner && other.GetComponent<TankBase>() != null)
        {
            other.gameObject.GetComponent<TankBase>()?.Wound(bulletDamage);
            Destroy(this.gameObject);
        }
    }
    
    public void FindOwner(GameObject bulletOwner)
    {
        owner = bulletOwner;
    }

    public void  setBulletDamage(float damage)
    {
        bulletDamage = damage;
    }
  
}
