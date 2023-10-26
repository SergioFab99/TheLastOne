using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float speed = 90f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si la colisión es con un objeto que tiene la etiqueta "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            // Destruimos la bala
            Destroy(gameObject);

            // Realiza aquí las acciones relacionadas con el daño al enemigo.
            // Puedes acceder al componente del enemigo y reducir su vida, por ejemplo.
            // Ejemplo: collision.GetComponent<Enemy>().RecibirDanio(10);
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }
}
