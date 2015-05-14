using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public GameObject laserPrefab;
    public GameObject parentObject;
    public int rotationOffset = 0;
    private float scaling;

    void Start()
    {
        laserPrefab.transform.parent = transform;
        transform.parent = parentObject.transform;
    }

    void Update () {
        

        if (Input.GetButton("Fire1"))
        {

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

            scaling += 0.5f;
            laserPrefab.transform.localPosition = new Vector2(transform.localPosition.x + scaling/2.86f, 0);
            laserPrefab.transform.localScale = new Vector3(transform.localScale.x + scaling, 1, 0);

        }
        else if (!Input.GetButton("Fire1"))
        {
            transform.position = parentObject.transform.position;
            scaling = 0;
            laserPrefab.transform.localScale = new Vector2(0, 1);
            laserPrefab.transform.localPosition = transform.position;
        }

    }
}