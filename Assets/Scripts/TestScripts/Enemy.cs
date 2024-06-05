using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyDamage = 1f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(enemyDamage);
        }
    }

}
