using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollection : MonoBehaviour
{
    //传入武器预设体，作为该收集物的武器池，随机获取一个装载
    public WeaponBase[] weapons;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            WeaponBase weapon = weapons[Random.Range(0,weapons.Length)];
            other.gameObject.GetComponent<PlayerTank>().SetWeapon(weapon.gameObject);
            weapon.FindOwner(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        gameObject.transform.Rotate(Vector3.up*Time.deltaTime*50);
    }
}
