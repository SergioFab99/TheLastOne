using UnityEngine;
using System.Collections;

public class Metralleta : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 0.5f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;
    
    // Escala original de la metralleta
    private Vector3 escalaOriginal;

    void Start()
    {
        camera = Camera.main; // Busca la cámara principal
        // Guarda la escala original al inicio
        escalaOriginal = transform.localScale;
    }
    
    void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            StartCoroutine(Rafaga());
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
        // Mantén la escala original de la metralleta
        transform.localScale = escalaOriginal;
    }

    IEnumerator Rafaga()
    {
        for (int i = 0; i < 3; i++)
        {
            Disparar();
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadDisparo;
    }
}
