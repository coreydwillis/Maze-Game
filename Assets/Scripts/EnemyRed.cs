using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRed : Enemy
{
    // INHERITANCE
    void Start()
    {
        walkPointRange = 20;
        sightRange = 30f;
        attackRange = 1f;
        timeBetweenAttacks = 1f;
    }

    public override void Update()
    {
        base.Update();
    }
}