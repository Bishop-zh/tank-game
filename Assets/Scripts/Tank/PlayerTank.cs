using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    private float v;
    private float h;
    private float headH;        
    public GameObject tankHead;
    [Header("武器装载位置")]
    public Transform[] weaponsTransform;

    private float screenWidth = Screen.width;
    private float screenHight = Screen.height;
    public Texture hpBackGroundTexture;
    public Texture hpTexture;
    public GUIStyle hpStyle;
    //血量显示参数

    void Update()
    {
        //读取当前屏幕分辨率
        screenWidth = Screen.width;
        screenHight = Screen.height;
        //获取位移参数
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        headH = Input.GetAxis("Mouse X");

        //返回bool值，按下时持续为真，参数0为左键1为右键2为中键
        //按下开火键并且不是暂停状态可以开火
        if(Input.GetMouseButtonDown(0)&&Time.timeScale != 0)
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        //前后位移
        transform.Translate(v*Vector3.forward*runSpeed*Time.deltaTime);
        //左右旋转
        transform.Rotate(h*Vector3.up*rotateSpeed*Time.deltaTime);
        //炮口旋转
        tankHead.transform.Rotate(headH*Vector3.up*headRotateSpeed*Time.deltaTime);
    }

    //根据当前血量来动态的修改ui界面血条长度，实时显示血量    
    void OnGUI()
    {
        //绘制血量以及血量底图（血量显示尝试进一步优化为可按血量分格显示）
        GUI.DrawTexture(new Rect(50, screenHight - 100, 300, 50), hpBackGroundTexture);
        //设置血条颜色
        GUI.color = Color.red;
        //根据玩家血量百分比动态计算血条长度
        GUI.DrawTexture(new Rect(57, screenHight - 90, 285 * (hp/maxHp), 35), hpTexture);
        GUI.color = Color.white;
        GUI.Label(new Rect(50, screenHight - 50, 300, 50), hp.ToString("F2") + "/" + maxHp.ToString("F2"), hpStyle);
    }

    //切换当前武器，暂未实现多武器同时持有，每次替换当前武器数组中第一个武器
    public void SetWeapon(GameObject weapon)
    {
        //为多武器选择以及武器切换功能做准备位置做准备
        int i =0;
        {
            if(weapons[i] != null)
            {
                Destroy(weapons[i].gameObject);
                weapons[i] = null;
            }
            //Instantiate()第三个参数作用为保留原本缩放大小
            GameObject newWeapon = Instantiate(weapon, weaponsTransform[i], false);
            weapons[i] = newWeapon.GetComponent<WeaponBase>();
            weapons[i].FindOwner(this.gameObject);
        }        
    }

    public void GetStatsBuff(int index)
    {
        switch(index)
        {
            case 0:
                damageMultiplier += 0.2f;
                GameSceneUI.UpdateTip("伤害提升20%");
                break;
            case 1:
                if(fireIntervalScale > 0.2f)
                {
                fireIntervalScale -= 0.2f;
                GameSceneUI.UpdateTip("射击间隔缩短20%");
                }
                else
                {
                    GameSceneUI.UpdateTip("射击间隔已达到最短，无法继续缩短");
                }
                break;
            case 2:
                runSpeed += 1f;
                GameSceneUI.UpdateTip("移动速度提升1");
                break;
            case 3:
                maxHp += 20f;
                hp += 20f;
                GameSceneUI.UpdateTip("最大血量提升20");
                break;
            case 4:
                defent += 5f;
                GameSceneUI.UpdateTip("防御力提升5");
                break;
        }
    }

}
