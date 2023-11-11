using UnityEngine;
using System.Collections;

public class Bazooka : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 3f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;

    void Start()
    {
        camera = Camera.main; // Busca la cámara principal
    }

    void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadDisparo;
    }
}
