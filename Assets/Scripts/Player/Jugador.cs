using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}
