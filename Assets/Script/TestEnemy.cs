using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public Player player;
    [SerializeField] private int Hp = 10;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && player.dashReady)
        {
            Debug.Log("À¸¾Ç");
        }
    }
}
