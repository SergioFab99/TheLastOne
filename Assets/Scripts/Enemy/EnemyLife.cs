using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int health = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 25;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    //si colisiona con el compate tag "Player" ,destruir al player
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            Destroy(col.gameObject);
            Application.LoadLevel("Derrota"); 
        }
    }
}