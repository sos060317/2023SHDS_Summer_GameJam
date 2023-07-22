using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{
    [SerializeField] protected float Boss_BulletATK;

    void Update()
    {
        transform.Translate(Vector3.forward * 0.05f);   // 보스 탄환 날아감
    }
}
