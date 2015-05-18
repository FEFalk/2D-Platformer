using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject parentObject;
    public GameObject laserPrefab;
    public int rotationOffset = 0;
    private float scaling;

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;

    private RaycastHit2D hit;
    private LineRenderer lr;

    void Start()
    {
        lr = laserPrefab.GetComponent<LineRenderer>();
    }

    void Update () {
        transform.position = parentObject.transform.position;

        if (Input.GetButton("Fire1"))
        {
            hit = Physics2D.Raycast(transform.localPosition, transform.right*100, 1 << LayerMask.NameToLayer("Ground"));
            Debug.Log(hit.collider.tag);
            Debug.DrawRay(transform.position, transform.right * 100, Color.red);

            mouse_pos = Input.mousePosition;
            mouse_pos.z = 5.23f; //The distance between the camera and object
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            Vector2 diff = new Vector2(transform.position.x-hit.point.x, transform.position.y-hit.point.y);

            lr.SetPosition(1, new Vector2(diff.magnitude, 0));

            Debug.Log("Point: " + hit.point.x + ", " + hit.point.y + " -- Line: " + lr.transform.position.x + ", " + lr.transform.position.y);
            //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //difference.Normalize();
            //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //if (transform.localScale.x == -1)
            //    transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + rotationOffset);
            //else
            //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            ////if(laserPrefab.GetComponent<LaserMovement>().hit!=true)
            ////    scaling += 0.5f;
            //laserPrefab.transform.localPosition = new Vector2(transform.localPosition.x + scaling/2.86f, 0);
            //laserPrefab.transform.localScale = new Vector3(transform.localScale.x + scaling, 1, 0);
            if(hit.collider.tag=="Blue Box")
            {
                hit.collider.transform.position = lr.transform.position;
            }

        }
        else if (!Input.GetButton("Fire1"))
        {
            lr.SetPosition(1, new Vector2(0, 0));
        }

    }
}