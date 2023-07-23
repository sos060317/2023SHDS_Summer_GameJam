using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float BulletATK;

    void Start()
    {
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 0.02f);   // 탄환 날아감
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Weppon"))
        {
            Destroy(gameObject);
        }
    }
}
