using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pistola : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float cooldown = 1f;
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
        // Aquí puedes agregar la lógica adicional del disparo de la pistola
    }
}
