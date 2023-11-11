using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Metralleta : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public int balasPorRafaga = 3;
    public float tiempoEntreBalas = 0.2f;
    public float cooldown = 0.2f;
    private float tiempoUltimoDisparo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            StartCoroutine(DispararRafaga());
            tiempoUltimoDisparo = Time.time;
        }
    }

    IEnumerator DispararRafaga()
    {
        for (int i = 0; i < balasPorRafaga; i++)
        {
            Disparar();
            yield return new WaitForSeconds(tiempoEntreBalas);
        }
    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        // Aquí puedes agregar la lógica adicional del disparo de la metralleta
    }
}
