using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bala : MonoBehaviour
{
    // La velocidad de la bala
    public float speed = 30f;

    // La dirección de la bala
    public Vector3 direction;

    // El método que se ejecuta cada frame
    void Update()
    {
        // Mover la bala
        transform.position += direction * Time.deltaTime * speed;
        //destruir despues de 2 segundos
        Destroy(gameObject, 2f);
    }
}
