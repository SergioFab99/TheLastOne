using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadBala = 15.0f;

    void Update()
    {
        // Detectar clic del mouse (botón izquierdo)
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Obtener la posición del mouse en el mundo
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección hacia la que apunta el mouse desde el punto de disparo
        Vector2 direccionDisparo = (mousePosition - (Vector2)puntoDisparo.position).normalized;

        // Crear una instancia de la bala y dispararla en la dirección del mouse
        GameObject nuevaBala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = nuevaBala.GetComponent<Rigidbody2D>();
        rbBala.velocity = direccionDisparo * velocidadBala;

        // Girar la bala para que se alinee con la dirección del disparo
        float anguloDisparo = Mathf.Atan2(direccionDisparo.y, direccionDisparo.x) * Mathf.Rad2Deg;
        nuevaBala.transform.rotation = Quaternion.Euler(new Vector3(0, 0, anguloDisparo));
    }
}

