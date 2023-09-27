using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDisparo : MonoBehaviour
{
    public GameObject bulletPrefab;          
    public Transform firePoint;             
    public float bulletSpeed = 15.0f;       
    public float cooldownTime = 0.3f;       

    private float lastShotTime = 0.0f;      

    void Update()
    {
        // Detect left mouse button click and check for cooldown
        if (Input.GetButtonDown("Fire1") && Time.time - lastShotTime >= cooldownTime)
        {
            Shoot();
            lastShotTime = Time.time; // Update the last shot time
        }
    }

    void Shoot()
    {
        // Get the mouse position in the world
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the fire point to the mouse
        Vector2 shootDirection = (mousePosition - (Vector2)firePoint.position).normalized;

        // Create an instance of the bullet and shoot it in the mouse direction
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rbBullet = newBullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = shootDirection * bulletSpeed;
        Destroy(newBullet, 2.0f);

        // Rotate the bullet to align with the shoot direction
        float shootAngle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, shootAngle));
    }
}
