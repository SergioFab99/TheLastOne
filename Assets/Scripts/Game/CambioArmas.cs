using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CambioArmas : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public Image spriteGrande;


    public Sprite imagenEstado1;
    public Sprite imagenEstado2;

    private int estado = 0;
    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            estado = 1;
        }
        else if (scroll < 0f)
        {
            estado = 2;
        }

        ActualizarEstado();
    }

    private void Start()
    {
        estado = 1; // Establecer el estado inicial en 1
        ActualizarEstado();
    }

    private void ActualizarEstado()
    {
        if (estado == 1)
        {
            objeto1.SetActive(true);
            objeto2.SetActive(false);
            spriteGrande.sprite = imagenEstado1;
           
        }
        else if (estado == 2)
        {
            objeto1.SetActive(false);
            objeto2.SetActive(true);
            spriteGrande.sprite = imagenEstado2;
            
        }
    }


}

