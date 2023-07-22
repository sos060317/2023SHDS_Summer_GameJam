using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float E_moveSpeed;
    [SerializeField] private float E_dash_Delay;
    private float Cur_E_dash_Delay;

    private Transform player;
    
    Rigidbody rigid;

    Vector3 E_Movevec;
    Vector3 forwardVec;
    Vector3 targetPosition;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        E_Move();
        E_dash();
        CheckEnemyForward();
    }

    void E_Move() // 플레이어 추적해서 이동
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        transform.position += direction * E_moveSpeed * Time.deltaTime;
    }

    void E_dash()
    {
        if(E_dash_Delay > Cur_E_dash_Delay) // 대시 쿨타임
        {
            Cur_E_dash_Delay += Time.deltaTime;
        }
        else
        {
            
        }
    }
}
