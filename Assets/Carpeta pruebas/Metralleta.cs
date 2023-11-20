using UnityEngine;
using System.Collections;

public class Metralleta : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 0.5f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;
    public Transform Pistola;
    private GameObject Player;
    private AudioSource efectsound;
    [SerializeField] private AudioClip audioclip;

    // Escala original de la metralleta
    private Vector3 escalaOriginal;

    void Start()
    {
        efectsound = GetComponent<AudioSource>();
        camera = Camera.main; // Busca la cámara principal
        Player = GameObject.Find("Player");
        escalaOriginal = transform.localScale;
    }
    
    void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            StartCoroutine(Rafaga());
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - Player.transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
        float angle = GetAngleTowardsMouse();
        Vector3 scale = transform.localScale;
        if (mouseDirection.x < 0)
        {
            scale.y = -0.04f;
            scale.x = -0.04f;
        }
        else
        {
            scale.x = 0.04f;
            scale.y = 0.04f;
        }
        transform.localScale = scale;
    }

    private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;
        return angle;
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
         // Realizar el disparo
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            efectsound.PlayOneShot(audioclip);
            Destroy(bullet, 2f);
        //GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadDisparo;
    }
}
