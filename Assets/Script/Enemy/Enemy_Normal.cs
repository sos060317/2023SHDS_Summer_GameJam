using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : Enemy
{
    protected override void Update()
    {
        base.Update();
        player_fix = player;
        rotate();
    }
}
