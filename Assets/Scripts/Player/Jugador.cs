using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    private SpriteRenderer spriteRenderer; 
    private bool mirandoDerecha = false;
    private int life = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(movimientoHorizontal, movimientoVertical).normalized;
        Vector2 velocidad = direccion * velocidadMovimiento;

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = velocidad;

        if (movimientoHorizontal > 0 && !mirandoDerecha)
        {
            spriteRenderer.flipX = true;
            mirandoDerecha = true;
        }
        else if (movimientoHorizontal < 0 && mirandoDerecha)
        {
            spriteRenderer.flipX = false;
            mirandoDerecha = false;
        }
        //si la vida = 0 ,destruir al Jugador
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}