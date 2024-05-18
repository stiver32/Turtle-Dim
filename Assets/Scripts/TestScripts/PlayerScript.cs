using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static event Action OnPlayerDamaged;
    public float health;
    public float maxHealth;

    public float moveSpeed = 5f;
    public float rotateSpeed = 700f;


    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {

        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveHorizontal, moveVertical, 0));
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
