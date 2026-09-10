using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponBase : MonoBehaviour
{
    public float baseAtk = 30;
    public float baseInterval = 2f;
    //owner应该是创建他的炮口
    public GameObject owner;
    public GameObject bullet;

    //一个武器可以有多个炮口
    public Transform[] bulletTransform;
    private float lastFireTime = 0f;

    //显示武器冷却图标
    public Texture weaponIcon;
    public Texture weaponIconCoolDown;  
    public int weaponIndex;

    private float screenWidth = Screen.width;
    private float screenHight = Screen.height;
    //当前武器冷却时间
    public float currentCoolDownTime = 0f;
    private Rect weaponIconRect;
    
    void Update()
    {
        screenWidth = Screen.width;
        screenHight = Screen.height;
        //更新武器图标位置,可优化为为场景建立几个标准位置的常量，来实现全场景图标对齐
        weaponIconRect = new Rect(screenWidth - screenWidth/10 - screenWidth/10*weaponIndex, screenHight -screenHight/8, screenWidth/15 , screenWidth/15);
        //更新武器冷却时间
        if(currentCoolDownTime > 0)
        {
            currentCoolDownTime -= Time.deltaTime;            
        }
    }

    public void Fire(float damageMultiplier,float fireIntervalScale)
    {
        
        float atk = baseAtk*damageMultiplier;
        float interval = baseInterval*fireIntervalScale;
        currentCoolDownTime = interval;
        if (Time.time < lastFireTime + interval)
        {
            //Debug.Log("武器冷却中，无法发射，冷却时间剩余"+currentCoolDownTime.ToString("F2"));
            return;
        }
        lastFireTime = Time.time;
        for(int i = 0; i<bulletTransform.Length;i++)
        {
        //指定坐标创建不绑定为子对象
        GameObject newBullet = Instantiate(bullet,bulletTransform[i].position,bulletTransform[i].rotation);
        //传入子弹伤害
        newBullet.GetComponent<Bullet>()?.FindOwner(owner);
        newBullet.GetComponent<Bullet>()?.setBulletDamage(atk);
        }
    }

    public void FindOwner(GameObject weaponOwner)
    {
        owner = weaponOwner;
    }


    //显示当前武器的冷却状态
    void OnGUI()
    {        
        //只有玩家武器才会显示冷却状态，这里应该放入玩家坦克内部进行渲染
        if(owner.gameObject.GetComponent<PlayerTank>() == null)
        {
            return;
        }
        //绘制该武器冷却图
        GUI.DrawTexture(weaponIconRect, weaponIcon);
        //绘制冷却遮罩层,根据当前冷却时间来判断是否显示以及计算遮罩层大小
        GUI.color = Color.gray;
        //显示冷却秒数
        if(currentCoolDownTime > 0)
        {
            GUI.DrawTexture(weaponIconRect, weaponIconCoolDown);
            GUI.Label(weaponIconRect, currentCoolDownTime.ToString("F2"),style: new GUIStyle() { alignment = TextAnchor.MiddleCenter, fontSize = 20, normal = new GUIStyleState() { textColor = Color.black } });
        }
    }

    //是坦克对象持有的武器数组中第几个就传几+1的索引
    public void SetWeaponIndex(int index)
    {
        weaponIndex = index;
    }

}

