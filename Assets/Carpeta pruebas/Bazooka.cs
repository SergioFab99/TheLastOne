using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bazooka : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float cooldown = 4f; // Cooldown de 4 segundos
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
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        // Aquí puedes agregar la lógica adicional del disparo de la bazooka
    }
}
