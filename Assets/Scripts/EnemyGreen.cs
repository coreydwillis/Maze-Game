using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGreen : Enemy
{
    void Start()
    {
        walkPointRange = 3f;
        sightRange = 1f;
        attackRange = 1f;
        timeBetweenAttacks = 1f;
    }

    public override void Update()
    {
        base.Update();
    }
}