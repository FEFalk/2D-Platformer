﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RedLaser : MonoBehaviour {

    public GameObject parentObject;
    public GameObject laserPrefab;
    public GameObject Button;

    public bool activated;
    public int rotationOffset = 0;
    private float scaling;

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;

    private static RaycastHit2D hit;
    private LineRenderer lr;

    private int size;
    private Camera mainCamera;
    private Vector2 diff;
    public bool touching;
    private Touch touches;
    private Vector2 vectorSize;
    private Vector2 prevPos;
    void Start()
    {
        lr = laserPrefab.GetComponent<LineRenderer>();
        activated = false;
        size = 2;
        
    }

    void Update()
    {

        transform.position = parentObject.transform.position;
        laserPrefab.transform.position = parentObject.transform.position;
        prevPos = transform.position;
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        bool isPointerOverGameObject = false;

        if (EventSystem.current.currentInputModule is TouchInputModule)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                if (EventSystem.current.IsPointerOverGameObject(Input.touches[i].fingerId))
                {
                    touching = false;
                    isPointerOverGameObject = true;
                    break;
                }
            }
        }
        else
        {
            isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
        }

        if ((Input.GetButton("Fire1") || Input.touchCount > 0) && isPointerOverGameObject == false)
            touching = true;
        else
            touching = false;

        

        if ((Input.GetButton("Fire1") || Input.touchCount > 0) && isPointerOverGameObject == false)
        {
            
            if (activated == false && touching == true)
                hit = Physics2D.Raycast(parentObject.transform.position, transform.right * 100, 1 << LayerMask.NameToLayer("Ground"));
            else
                hit = Physics2D.Raycast(parentObject.transform.position, -diff, 1 << LayerMask.NameToLayer("Ground"));

            //Debug.Log(hit.collider.tag);
            Debug.DrawRay(transform.position, transform.right * 100, Color.red);

            if (activated == false && touching == true)
            {
                diff = new Vector2(parentObject.transform.position.x - hit.point.x, parentObject.transform.position.y - hit.point.y);
                lr.SetPosition(1, -diff);
            }
            if (touching == true)
            {
           //     if (!hit.rigidbody)
           //         return;
                if (hit.collider != null)
                {
                    if(hit.collider.tag == ("Enemy")) 
                        Destroy(hit.collider.gameObject);
                }
            }
            
        }
        else if (!Input.GetButton("Fire1") || Input.touchCount <= 0)
            {
                activated = false;
                lr.SetPosition(1, new Vector2(0,0));
                touching = false;
                Camera.main.GetComponent<SmoothCamera2D>().target = parentObject.transform;
            }
    } // end of update
}
