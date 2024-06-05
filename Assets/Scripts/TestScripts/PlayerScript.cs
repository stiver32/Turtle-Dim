using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{

    private Inputs playerInput;
    private Guard playerGuard;
    public static event Action OnPlayerDamaged;
    public float health;
    public float maxHealth;
  


    private void Start()
    {

        health = maxHealth;
        playerInput = GetComponent<Inputs>();
        playerInput.myAnimator = GetComponent<Animator>();
        playerInput.mySprite = GetComponent<SpriteRenderer>();
        playerGuard = GetComponent<Guard>();

    }

    private void Update()
    {
        playerInput.Move();
        playerInput.Shoot();
        playerGuard.GuardPressed();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();


        if (health <= 0)
        {
            health = 0;
            Debug.Log("You're dead");
        }

    }


}
