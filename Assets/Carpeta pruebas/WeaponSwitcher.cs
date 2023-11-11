using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponSwitcher : MonoBehaviour
{
    // El índice del arma actual
    public int currentWeapon = 0;

    // El arreglo de las armas disponibles
    public GameObject[] weapons;

    // El tiempo que se debe esperar entre cada cambio de arma
    public float switchDelay = 0.5f;

    // El tiempo que ha pasado desde el último cambio de arma
    private float switchTimer = 0f;

    // El método que se ejecuta al iniciar el juego
    void Start()
    {
        // Activar el arma inicial y desactivar las demás
        SelectWeapon(currentWeapon);
    }

    // El método que se ejecuta cada frame
    void Update()
    {
        // Actualizar el temporizador
        switchTimer += Time.deltaTime;

        // Obtener el input del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Si el input es positivo, cambiar al arma siguiente
        if (scroll > 0f && switchTimer > switchDelay)
        {
            // Incrementar el índice del arma actual
            currentWeapon++;

            // Si el índice supera el límite, volver al inicio
            if (currentWeapon >= weapons.Length)
            {
                currentWeapon = 0;
            }

            // Activar el arma actual y desactivar las demás
            SelectWeapon(currentWeapon);

            // Reiniciar el temporizador
            switchTimer = 0f;
        }

        // Si el input es negativo, cambiar al arma anterior
        if (scroll < 0f && switchTimer > switchDelay)
        {
            // Decrementar el índice del arma actual
            currentWeapon--;

            // Si el índice es menor que cero, ir al final
            if (currentWeapon < 0)
            {
                currentWeapon = weapons.Length - 1;
            }

            // Activar el arma actual y desactivar las demás
            SelectWeapon(currentWeapon);

            // Reiniciar el temporizador
            switchTimer = 0f;
        }
    }

    // El método que activa el arma seleccionada y desactiva las demás
    void SelectWeapon(int index)
    {
        // Recorrer el arreglo de las armas
        for (int i = 0; i < weapons.Length; i++)
        {
            // Si el índice coincide con el seleccionado, activar el arma
            if (i == index)
            {
                weapons[i].SetActive(true);
            }
            // Si no, desactivar el arma
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
