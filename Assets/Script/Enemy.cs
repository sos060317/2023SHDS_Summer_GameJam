using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float E_moveSpeed;

    Rigidbody rigid;

    Vector3 E_Movevec;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    void E_Move()
    {
        
    }
}
