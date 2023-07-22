using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Player player;
    [SerializeField] private int Hp = 10;

    public GameObject hitEffect;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && player.isDash)
        {
            Hit();
            Debug.Log("발도맞음");
        }
        if (other.gameObject.CompareTag("Slash"))
        {
            Hit();
            Debug.Log("칼맞음");
        }
    }

    public void Hit()
    {
        var _hitEffect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(_hitEffect, 0.5f);
    }
}
