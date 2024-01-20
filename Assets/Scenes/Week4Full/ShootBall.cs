using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float speed = 100f;
    public float shootCooldown = 0.5f; // Set the cooldown time to half a second

    private float lastShootTime;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }

        // Consider using Time.deltaTime to destroy bullets after a certain time
        if (Time.time > lastShootTime + 80f)
        {
            DestroyBullet();
        }
    }

    void Shoot()
    {
        if (shootPoint == null)
        {
            Debug.LogError("Shoot point not assigned!");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Instantiate the bullet at the shootPoint position
            GameObject bulletInstance = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();

            if (bulletRb != null)
            {
                // Calculate the direction towards the hit point
                Vector3 direction = (hit.point - shootPoint.position).normalized;

                // Set the bullet's rotation to face the hit point using the normal as the up direction
                bulletInstance.transform.rotation = Quaternion.LookRotation(direction);

                // Set the bullet's velocity to move towards the hit point
                bulletRb.velocity = direction * speed;
            }
        }
    }

    void DestroyBullet()
    {
        // Assuming the bulletPrefab is the same as the instantiated bullet, you can destroy it after a certain time.
        Destroy(bulletPrefab);
    }
}
