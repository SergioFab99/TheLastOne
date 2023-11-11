using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metralleta : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 0.5f;
    private float tiempoUltimoDisparo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            StartCoroutine(Rafaga());
            tiempoUltimoDisparo = Time.time;
        }
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidadDisparo;
    }
}
