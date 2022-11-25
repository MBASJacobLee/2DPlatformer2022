using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerLife : MonoBehaviour
{

[SerializeField] private int damage;
[SerializeField] private Health playerHealth;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player touches the spikes the player losses health
        if (collision.gameObject.CompareTag("Trap"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
