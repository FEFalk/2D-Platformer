using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public GameObject laserPrefab;
    private Vector3 startPosition;
    public int rotationOffset = 0;
    private float scaling;

    void Start()
    {
        startPosition = laserPrefab.transform.position;
    }

    void Update () {
        

        if (Input.GetButton("Fire1"))
        {

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

            scaling += 2;
            laserPrefab.transform.position = new Vector3(transform.position.x + scaling, 0);
            laserPrefab.transform.localScale = new Vector3(transform.localScale.x + scaling, 1, 0);

        }
        else if (!Input.GetButton("Fire1"))
        {
            scaling = 0;
            laserPrefab.transform.localScale = new Vector2(0, 1);
            laserPrefab.transform.position = startPosition;
        }

    }
}