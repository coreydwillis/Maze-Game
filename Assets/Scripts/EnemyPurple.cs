using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPurple : Enemy
{
    // INHERITANCE
    void Start()
    {
        walkPointRange = 2f;
        sightRange = 20f;
        attackRange = 1f;
        timeBetweenAttacks = 5f;
    }

    public override void Update()
    {
        base.Update();
    }
}