using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int health = 100;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            health -= 25;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}