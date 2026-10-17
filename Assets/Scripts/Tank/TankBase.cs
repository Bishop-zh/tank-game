using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBase : MonoBehaviour
{
    
        [Header("生存属性")]
        public float maxHp = 100;                // 最大血量
        public float hp = 100;                   // 当前血量
        public float defent = 0;              // 防御力
        
        [Header("战斗属性")]
        public float damageMultiplier = 1f;     // 伤害倍率
        public float fireIntervalScale = 1f;         // 射击间隔衰减，百分比
        public WeaponBase[] weapons;           // 搭载的武器数组
        
        [Header("移动属性")]
        public float runSpeed = 5f;             // 前后移动速度
        public float rotateSpeed = 50f;          // 车身转向速度
        public float headRotateSpeed = 20;      // 炮台转向速度

      
    protected virtual void Awake()
    {
        if (weapons == null || weapons.Length == 0) weapons = GetComponentsInChildren<WeaponBase>();
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == null) continue;
            weapons[i].FindOwner(gameObject);
            weapons[i].SetWeaponIndex(i + 1);
        }
    }

    //发射子弹方法,获取武器信息发射对应子弹，根据角色攻击力计算子弹最终伤害
    public void Fire()
    {        
        for(int i = 0; i<weapons.Length; i++)
        {
            if (weapons[i] != null) weapons[i].Fire(damageMultiplier,fireIntervalScale);
        }
    }

    //死亡事件处理，角色弹出死亡提升，怪物死亡执行加分等事件,设置为虚函数便于子类重写
    public virtual void Death()
    {
        //死亡就销毁当前对象，在其他子类中从写来完成相应功能
        Destroy(this.gameObject);
    }

    //受伤时候调用，执行主要根据防御力计算实际受伤，定义为虚函数方便子类进行创建掉落物和加分特效等操作
    public virtual void Wound(float finalAtk)
    {
        float takeDamage = finalAtk - defent;
        if(takeDamage <= 0)
        {
            return;
        }
        hp -= takeDamage;
        if (hp <= 0)
        {
            Death();
        }
    }
  
}