using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_long : Enemy
{
    [SerializeField] private float E_Bullet_Delay;
    private float Cur_E_Bullet_Delay = 0;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform Gun;

    protected override void Update()
    {
        base.Update();
        gun();
    }

    void gun()
    {
        if(E_Bullet_Delay > Cur_E_Bullet_Delay)
        {
            Cur_E_Bullet_Delay += Time.deltaTime;
        }
        else
        {
            player_fix = player;
            rotate();
            Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
            Cur_E_Bullet_Delay = 0;
        }
    }
}
