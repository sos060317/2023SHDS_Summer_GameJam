using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerstat;

    public float health;

    public float damage;
    public float attackDistance;

    public float dashDamage;
    public float dashDistance;
    public float dashCoolTime;

    public float moveSpeed;

    private void Awake()
    {
        playerstat = this;
    }
}
