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
    private Transform player_fix;
    
    
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

        //Vector3 direction = player.position - transform.position;
        //direction.Normalize();
        
        transform.Translate(Vector3.forward * E_BoosterSpeed);

        //transform.position += direction * E_BoosterSpeed * Time.deltaTime;
        Cur_E_dash_Delay = 0;
    }

    void rotate() // 플레이어를 바라보는 함수
    {
        Vector3 dir = player_fix.transform.position - transform.position;
        dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        transform.rotation = rot;
    }
}
