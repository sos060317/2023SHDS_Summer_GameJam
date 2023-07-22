using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy
{
    [SerializeField] protected float E_Boss_DashATK;
    [SerializeField] private float E_Boss_BoosterSpeed;
    [SerializeField] private float E_Boss_dash_Delay;
    private float Cur_E_Boss_dash_Delay = 0;

    [SerializeField] private float E_Boss_Bullet_Delay;
    private float Cur_E_Boss_Bullet_Delay = 0;

    [SerializeField] private GameObject Boss_Bullet;
    [SerializeField] private Transform Boss_Gun;
    [SerializeField] private Transform Boss_Gun2;
    [SerializeField] private Transform Boss_Gun3;
    
    protected override void Update()
    {
        base.Update();
        E_Boss_dash_CoolTime();
        boss_Gun();
    }

    void E_Boss_dash_CoolTime() // 대시의 쿨타임이 돌 때마다 보스가 대시한다.
    {
        if(E_Boss_dash_Delay > Cur_E_Boss_dash_Delay)
        {
            Cur_E_Boss_dash_Delay += Time.deltaTime;
        }
        else
        {
            player_fix = player;
            rotate();
            StartCoroutine(E_Boss_dash());
        }
    }

    IEnumerator E_Boss_dash() // 보스 대시
    {
        yield return new WaitForSeconds(0.15f);
        
        transform.Translate(Vector3.forward * E_Boss_BoosterSpeed);

        Cur_E_Boss_dash_Delay = 0;
    }

    void boss_Gun() // 쿨타임마다 보스 탄환 생성
    {
        if(E_Boss_Bullet_Delay > Cur_E_Boss_Bullet_Delay)
        {
            Cur_E_Boss_Bullet_Delay += Time.deltaTime;
        }
        else
        {
            player_fix = player;
            rotate();
            Instantiate(Boss_Bullet, Boss_Gun.transform.position, Boss_Gun.transform.rotation);
            Instantiate(Boss_Bullet, Boss_Gun2.transform.position, Boss_Gun2.transform.rotation);
            Instantiate(Boss_Bullet, Boss_Gun3.transform.position, Boss_Gun3.transform.rotation);

            Cur_E_Boss_Bullet_Delay = 0;
        }
    }
}
