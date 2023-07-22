using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float BulletATK;

    void Update()
    {
        transform.Translate(Vector3.forward * 0.05f);   // 탄환 날아감
    }
}
