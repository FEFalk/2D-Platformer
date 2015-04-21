using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    public Vector3 bulletOffset = new Vector3(0.5f, 0, 0);

	void Update () {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("PeW!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset; 
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
	}
}
