using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dash : Enemy
{
    [SerializeField] private float E_BoosterSpeed;
    [SerializeField] private float E_dash_Delay;
    private float Cur_E_dash_Delay = 0;
    
    protected override void Update()
    {
        base.Update();
        E_dash_CoolTime();
    }

    void E_dash_CoolTime() // 대시의 쿨타임이 돌 때마다 적이 대시한다.
    {
        if(E_dash_Delay > Cur_E_dash_Delay)
        {
            Cur_E_dash_Delay += Time.deltaTime;
        }
        else
        {
            player_fix = player;
            rotate();
            StartCoroutine(E_dash());
        }
    }

    IEnumerator E_dash() // 적 대시
    {
        yield return new WaitForSeconds(0.15f);
        
        transform.Translate(Vector3.forward * E_BoosterSpeed);

        Cur_E_dash_Delay = 0;
    }
}
