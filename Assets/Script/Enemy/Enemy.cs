using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float E_HP;
    [SerializeField] protected float E_ATK;

    [SerializeField] protected float E_moveSpeed;
    [SerializeField] protected Transform player;
    protected Transform player_fix;
    
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    protected virtual void Update()
    {
        E_Move();
    }

    void E_Move() // 플레이어 추적해서 이동
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        transform.position += direction * E_moveSpeed * Time.deltaTime;
    }

    protected void rotate() // 플레이어를 바라보는 함수
    {
        if(transform != null){
            Vector3 dir = player_fix.transform.position - transform.position;
            dir.y = 0f;

            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;
        }
    }
}