using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_long : Enemy
{
    [SerializeField] private float E_Bullet_Delay;
    private float Cur_E_Bullet_Delay = 0;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform Gun;
    

    protected virtual void Start()
    {
        base.Start();
        Gun = transform.GetChild(1);
    }

    protected override void Update()
    {
        base.Update();
        player_fix = player;
        rotate();
        gun();
    }

    void gun() // 쿨타임이 돌면 탄환 생성
    {
        if(E_Bullet_Delay > Cur_E_Bullet_Delay)
        {
            Cur_E_Bullet_Delay += Time.deltaTime;
        }
        else
        {
            Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
            Cur_E_Bullet_Delay = 0;
        }
    }
}
