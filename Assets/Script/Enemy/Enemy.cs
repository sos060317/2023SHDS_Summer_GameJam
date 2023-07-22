using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float E_HP;
    [SerializeField] protected float E_ATK;
    [SerializeField] protected float E_EXP;
    [SerializeField] protected float E_moveSpeed;
    [SerializeField] protected Transform player;
    protected Transform player_fix;
    
    Rigidbody rigid;

    [SerializeField] private int Hp = 10;

    public GameObject hitEffect;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("발도맞음");
        }
        if (other.gameObject.CompareTag("Slash"))
        {
            Debug.Log("칼맞음");
        }
    }

    public void OnDamaged(float damage)
    {
        Debug.Log("hfk");
        var _hitEffect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(_hitEffect, 0.5f);
        E_HP -= damage;

        if (E_HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}