using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;

    void Update()
    {
        // Obtén las entradas de teclado o controles
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula la dirección del movimiento
        Vector2 direccion = new Vector2(movimientoHorizontal, movimientoVertical).normalized;

        // Calcula la velocidad de movimiento
        Vector2 velocidad = direccion * velocidadMovimiento;

        // Aplica la velocidad al Rigidbody2D del jugador
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = velocidad;
    }
}