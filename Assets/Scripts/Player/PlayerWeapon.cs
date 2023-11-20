using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject Player;
    public new Camera camera;
    public GameObject bulletPrefab;
    public Transform spawner;
    private AudioSource efectsound;
    [SerializeField] private AudioClip audioclip;
    public float fireCooldown = 0.9f; // Tiempo de enfriamiento entre disparos
    private float currentCooldown = 0f;
    // Tiempo transcurrido desde el último disparo

    // Start is called before the first frame update
    void Start()
    {
        efectsound = GetComponent< AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
        CheckFiring();
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

    private void CheckFiring()
    {
        currentCooldown -= Time.deltaTime; // Restamos tiempo desde el último disparo

        if (Input.GetMouseButtonDown(0) && currentCooldown <= 0)
        {
            // Realizar el disparo
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            Destroy(bullet, 2f);
            efectsound.PlayOneShot(audioclip);

            // Establecer el tiempo de enfriamiento
            currentCooldown = fireCooldown;
        }
    }
}
