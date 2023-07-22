using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerstat;

    [Header("Status")]
    public float health;

    public float damage;
    public float attackDistance;

    public float dashDamage;
    public float dashDistance;
    public float dashCoolTime;

    public float moveSpeed;

    [Header("SkillOnOff")]
    public bool onSwordWind;
    public bool onAbsorption;

    public bool onSlow;
    public bool rotationSword;

    private void Awake()
    {
        playerstat = this;
    }
}
