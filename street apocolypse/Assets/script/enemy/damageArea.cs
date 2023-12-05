using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageArea : MonoBehaviour
{
   public int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        playermovement health = other.GetComponent<playermovement>();

        if(health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}

