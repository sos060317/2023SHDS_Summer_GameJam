using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float E_moveSpeed;
    [SerializeField ]private float E_BoosterSpeed;
    [SerializeField] private float E_dash_Delay;
    private float Cur_E_dash_Delay = 0;
    private Transform player;
    
    Rigidbody rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        E_Move();
        E_dash_CoolTime();
    }

    void E_Move() // 플레이어 추적해서 이동
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        transform.position += direction * E_moveSpeed * Time.deltaTime;
    }

    void E_dash_CoolTime() // 대시의 쿨타임이 돌 때마다 몬스터가 대시한다.
    {
        if(E_dash_Delay > Cur_E_dash_Delay)
        {
            Cur_E_dash_Delay += Time.deltaTime;
        }
        else
        {
            StartCoroutine(E_dash());
        }
    }

    IEnumerator E_dash() // 몬스터 대시
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        transform.position += direction * E_BoosterSpeed * Time.deltaTime;
        Cur_E_dash_Delay = 0;
    }
}
