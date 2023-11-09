using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Boss : MonoBehaviour
{
    // Variable para el Rigidbody2D del boss
    private Rigidbody2D rb;
    public Jugador jugador;
    // Variable para la velocidad del boss
    public float speed = 5f;

    // Variable para la direcci�n del boss
    private Vector2 direction = Vector2.left;

    // Variable para el l�mite izquierdo del movimiento
    public float leftLimit;

    // Variable para el l�mite derecho del movimiento
    public float rightLimit;

    // Variable para la vida del boss
    public int health = 100;

    // Variable para el valor de vida que indica que el boss est� herido
    public int hurtValue = 50;

    // Variable para el estado del boss
    private string state = "normal";

    // Variable para el prefab de la bala
    public GameObject bulletPrefab;

    // Variable para la posici�n de salida de la bala
    public Transform bulletSpawn;

    // Variable para la velocidad de la bala
    public float bulletSpeed = 10f;

    // Variable para el intervalo de tiempo entre disparos
    public float shootInterval = 1f;

    // Variable para el contador de tiempo
    private float timer = 0f;
    private int damage = 10;
    void Start()
    {
        // Obtener el componente Rigidbody2D del boss
        rb = GetComponent<Rigidbody2D>();
        float initialPosition = transform.position.x;
        leftLimit = initialPosition - 4f;
        rightLimit = initialPosition + 4f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto es una bala
        if (other.gameObject.tag == "Bala")
        {
            // Reducir la vida del boss en 10 
            health -= damage;

            // Destruir la bala
            Destroy(other.gameObject);

            // Si la vida del boss es menor o igual a 0, destruirlo
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    // M�todo que se ejecuta en cada frame del juego
    void Update()
    {
        // Comparar la vida del boss con el valor de vida que indica que est� herido
        if (health <= hurtValue)
        {
            // Cambiar el estado del boss a "hurt"
            state = "hurt";
        }

        // Ejecutar el c�digo seg�n el estado del boss
        switch (state)
        {
            case "normal":
                // Calcular la posici�n x del boss usando la funci�n PingPong
                float x = Mathf.PingPong(Time.time * speed, rightLimit - leftLimit) + leftLimit;

                // Crear un vector con la posici�n x y la posici�n y actual del boss
                Vector2 position = new Vector2(x, rb.position.y);

                // Mover el boss a la nueva posici�n usando la funci�n MovePosition
                rb.MovePosition(position);
                break;
            case "hurt":
                // Hacer que el boss se quede quieto
                rb.velocity = Vector2.zero;

                // Incrementar el contador de tiempo con el tiempo transcurrido desde el �ltimo frame
                timer += Time.deltaTime;

                // Comparar el contador de tiempo con el intervalo de tiempo entre disparos
                if (timer >= shootInterval)
                {
                    if (jugador != null)
                    {
                        // Calcular la direcci�n hacia la posici�n del jugador
                        Vector2 directionToPlayer = (jugador.transform.position - bulletSpawn.position).normalized;

                        // Disparar una bala hacia la direcci�n del jugador usando la funci�n Instantiate
                        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * bulletSpeed;

                        // Reiniciar el contador de tiempo a cero
                        timer = 0f;
                    }
                }

                break;
        }
    }
}