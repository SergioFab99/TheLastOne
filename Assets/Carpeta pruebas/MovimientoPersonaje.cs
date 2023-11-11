using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(movimientoHorizontal, movimientoVertical).normalized;
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}
