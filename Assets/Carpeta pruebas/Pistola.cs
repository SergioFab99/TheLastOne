using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 1f;
    private float tiempoUltimoDisparo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidadDisparo;
    }
}
