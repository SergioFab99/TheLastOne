using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public new Camera camera;
    public GameObject bulletPrefab;
    public Transform spawner;

    public float fireCooldown = 0.9f; // Tiempo de enfriamiento entre disparos
    private float currentCooldown = 0f;
    // Tiempo transcurrido desde el último disparo

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
        float angle = GetAngleTowardsMouse();
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        Vector3 scale = transform.localScale;
        scale.y = angle >= 90 && angle <= 270? -0.1f : 0.1f;
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

            // Establecer el tiempo de enfriamiento
            currentCooldown = fireCooldown;
        }
    }
}
