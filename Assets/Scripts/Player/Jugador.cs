using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float rangoAtaque = 2f; // Alcance del ataque cuerpo a cuerpo
    public LayerMask capaEnemigos; // Capa para identificar enemigos

    private Rigidbody2D rb2d;
    private bool mirandoDerecha = true;
    private Camera cam;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        MoverJugador();
        RotarJugador();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Se activa el cuerpo a cuerpo");
            AtaqueCuerpoACuerpo();
        }
    }

    void MoverJugador()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");
        Vector2 velocidad = new Vector2(movimientoHorizontal, movimientoVertical).normalized * velocidadMovimiento;
        rb2d.velocity = velocidad;
    }

    void RotarJugador()
    {
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if ((mouseWorldPosition.x > transform.position.x && !mirandoDerecha) ||
            (mouseWorldPosition.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }

    void AtaqueCuerpoACuerpo()
    {
        Debug.Log("Atacando...");

        // Detectar enemigos dentro del rango de ataque
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(transform.position, rangoAtaque, capaEnemigos);

        foreach (var enemigo in enemigosGolpeados)
        {
            // Comprobar si el objeto tiene el tag "Enemy"
            if (enemigo.CompareTag("Enemy"))
            {
                Destroy(enemigo.gameObject); // Destruir el objeto enemigo
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Esto es para visualizar el rango de ataque en el editor de Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}
