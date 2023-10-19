using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string escenaACargar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cargar la nueva escena cuando el jugador colisione con el área de detección.
            SceneManager.LoadScene(escenaACargar);
        }
    }
}
