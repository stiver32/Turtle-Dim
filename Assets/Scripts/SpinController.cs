using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : WeaponController
{
   
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpin = Instantiate(weaponData.prefab);

        spawnedSpin.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedSpin.transform.parent = transform;
    }

}
