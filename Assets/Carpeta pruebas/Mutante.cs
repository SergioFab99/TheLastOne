using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutante : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    public float chaseSpeed = 4.0f;
    private GameObject player;
    private bool isPlayerInRange = false;

    void Start()
    {
        // Intenta encontrar al jugador en la escena
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No se encontró un GameObject con la etiqueta 'Player'. Asegúrate de que el jugador esté etiquetado correctamente.");
            return;
        }

        // Configura el CircleCollider2D
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<CircleCollider2D>();
        }
        collider.isTrigger = true;
        collider.radius = detectionRadius;
    }

    void Update()
    {
        if (isPlayerInRange && player != null)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position);
            directionToPlayer.z = 0; // Asegura que no haya movimiento en el eje Z
            transform.position += directionToPlayer.normalized * chaseSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
