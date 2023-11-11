using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour
{
    // La velocidad de la bala
    public float speed = 100f;

    // La dirección de la bala
    public Vector3 direction;

    // El método que se ejecuta cada frame
    void Update()
    {
        // Mover la bala
        transform.position += direction * Time.deltaTime * speed;
    }
}
