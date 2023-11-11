using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlArmas : MonoBehaviour
{
    public GameObject pistola, metralleta, bazooka;
    private int armaSeleccionada = 0;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            if (scroll > 0f)
            {
                armaSeleccionada++;
                if (armaSeleccionada > 2) armaSeleccionada = 0;
            }
            else
            {
                armaSeleccionada--;
                if (armaSeleccionada < 0) armaSeleccionada = 2;
            }
            CambiarArma(armaSeleccionada);
        }
    }
    void CambiarArma(int arma)
    {
        pistola.SetActive(arma == 0);
        metralleta.SetActive(arma == 1);
        bazooka.SetActive(arma == 2);
    }
}
