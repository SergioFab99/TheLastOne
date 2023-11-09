using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            // Si colisiona con un objeto que tenga el tag "BulletEnemy", destruir el jugador
            Destroy(gameObject);
            SceneManager.LoadScene("Derrota");
        }
    }
}