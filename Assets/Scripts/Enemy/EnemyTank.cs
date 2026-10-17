using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBase
{

    public GameObject tankHead;
    public Transform[] targetTransforms;
    public Transform playerTank;
    
    //用于在屏幕渲染敌方坦克血条，
    //***三维坐标转为屏幕坐标，使用camear中方法.WorldToScreenPoint
    private Rect enemyTankHpRect;
    private Vector3 enemyTankHpPos;
    private float showHpTime = 30;
    public float showHpDuration = 3; //便于在编辑器进行修改

    //血条图片,使用GUI的color属性来切换血条颜色，达成空穴条和实际血条的区分
    public Texture enemyTankHpTexture;
    
    //当前正走向的目标点
    private int index = 0;

    


    //每帧进行目标点的移动以及判断范围内是否有敌人，以及进行开火
    void Update()
    {        
        MoveToTarget(targetTransforms);
        //根据地方坦克坐标计算血条在屏幕中显示坐标，（目前暂未判断不显示反向坦克血条，使用只在受击后显示代替）
        enemyTankHpPos = Camera.main.WorldToScreenPoint(transform.position);

        enemyTankHpPos -= new Vector3(Screen.width/40,(-1)*Screen.height/10);     

        //屏幕坐标系和unity相机的坐标系不同，一个原点在左上角，一个在左下角   
        enemyTankHpRect = new Rect(enemyTankHpPos.x,Screen.height-enemyTankHpPos.y,Screen.width/20,Screen.height/70);

        //检验武器是否冷却完毕
        if(weapons != null && weapons.Length > 0 && weapons[0] != null && weapons[0].currentCoolDownTime <= 0)
        {
            AtackPlayer();
        }        
        
    }

    

    //绘制敌方坦克血条
    private void OnGUI()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PortfolioBrowserFont.Apply();
#endif
        if(Camera.current != Camera.main)
        {
            return;
        }        
        if(showHpTime > 0f)
        {
           
            showHpTime -= Time.deltaTime;
            GUI.DrawTexture(enemyTankHpRect, enemyTankHpTexture);
            GUI.color = Color.red;

            //根据当前血量动态改变当前红色血条长度
            GUI.DrawTexture(new Rect(enemyTankHpRect.x,enemyTankHpRect.y,enemyTankHpRect.width*hp/maxHp,enemyTankHpRect.height), enemyTankHpTexture);
            GUI.color = Color.white;
        }
    }

    public override void Death()
    {
        GameSceneUI.AddScore(10);
        base.Death();
    }

    public override void Wound(float finalAtk)
    {
        //受击就显示数秒血条
        showHpTime = showHpDuration;
        float takeDamage = finalAtk - defent;
        if(takeDamage <= 0)
        {
            return;
        }
        hp -= takeDamage;
        if (hp <= 0)
        {
            //加分
            GameSceneUI.AddScore(50);
            Death();
        }
    }

    //设置目标点，随机在目标点之间移动
    public void MoveToTarget(Transform[] targets)
    {
        if (targets == null || targets.Length == 0 || targets[index] == null) return;
        //保持自身的z轴坐标向目标点位移
        transform.LookAt(new Vector3(targets[index].position.x, transform.position.y, targets[index].position.z));
        transform.Translate(Vector3.forward*runSpeed*Time.deltaTime);
        //检测当前位置接近目标点就切换目标，
        if (Vector3.Distance(transform.position, targets[index].position) < 2)
        {               
            index = Random.Range(0, targets.Length);
        }
    }

    //待优化方案：减少每帧对距离的计算，对角色位置进行预判性开火，而不是直接设计角色位置
    public void AtackPlayer()
    {
        if (playerTank != null && Vector3.Distance(transform.position, playerTank.position) < 6)
        {
            tankHead.transform.LookAt(playerTank);
            Fire();
        }
    }
    
}
