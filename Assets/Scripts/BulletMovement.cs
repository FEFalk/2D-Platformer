using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
    // Bullet
    public float bulletSpeed = 5f;
    public float timer = 1f;
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(bulletSpeed * Time.deltaTime, 0, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
