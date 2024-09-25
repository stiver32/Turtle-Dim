using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab);
        spawnedKnife.transform.position = transform.position; //Assign position to be same as this object which is parented to player
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.moveDir); // Reference and set direction
    }
}