using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GreenLaser : MonoBehaviour
{

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
    private bool obstacleButton = false;

    private int size;
    public float distance = 0.2f;
    public float damper = 1.0f;
    public float frequency = 8.0f;
    public float drag = 30.0f;
    public float angularDrag = 30.0f;
    private SpringJoint2D springJoint;
    private Camera mainCamera;
    private Vector2 diff;
    public bool touching;
    private Touch touches;

    void Start()
    {
        lr = laserPrefab.GetComponent<LineRenderer>();
        mainCamera = FindCamera();
        activated = false;
        size = 2;

    }

    void Update()
    {
        laserPrefab.transform.position = transform.position;
        transform.position = parentObject.transform.position;

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

        //if (hit.collider.tag == "ObstacleButton" && obstacleButton != true)
        //{
        //    obstacleButton = true;
        //    Button.GetComponent<ButtonHandler>().buttonActivate = true;
        //}

        if ((Input.GetButton("Fire1") || Input.touchCount > 0) && isPointerOverGameObject == false)
        {
            if (activated == false && touching == true)
                hit = Physics2D.Raycast(transform.localPosition, transform.right * 100, 1 << LayerMask.NameToLayer("Ground"));
            else
                hit = Physics2D.Raycast(transform.localPosition, -diff, 1 << LayerMask.NameToLayer("Ground"));

            //Debug.Log(hit.collider.tag);
            Debug.DrawRay(transform.position, transform.right * 100, Color.red);

            if (activated == false && touching == true)
            {
                diff = new Vector2(transform.position.x - hit.point.x, transform.position.y - hit.point.y);
                lr.SetPosition(1, -diff);
            }
            if (touching == true)
            {
                if (!hit.rigidbody)
                    return;
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "GreenButton")
                    {
                        transform.position = diff;
                        lr.SetVertexCount(size++);
                        Vector2 vectorSize = new Vector2(0, 0);
                        lr.SetPosition(size, vectorSize);
                        
                        activated = true;
                        diff = new Vector2(transform.position.x - hit.collider.transform.position.x, transform.position.y - hit.collider.transform.position.y);
                        lr.SetPosition(1, diff);
                        //lr.SetPosition(size -1, -diff);
                        //laserPrefab.transform.position = transform.position;
                        //transform.position = hit.transform.position;
                        //Camera.main.transform.position = parentObject.transform.position;
                        springJoint.transform.position = hit.point;
                    }

                    else
                        activated = false;
                    springJoint.distance = distance; // there is no distance in SpringJoint2D
                    springJoint.dampingRatio = damper;// there is no damper in SpringJoint2D but there is a dampingRatio
                    //springJoint.maxDistance = distance;  // there is no MaxDistance in the SpringJoint2D - but there is a 'distance' field
                    //  see http://docs.unity3d.com/Documentation/ScriptReference/SpringJoint2D.html
                    //springJoint.maxDistance = distance;
                    springJoint.connectedBody = hit.rigidbody;
                }
            }
            
        }
        else if (!Input.GetButton("Fire1") || Input.touchCount <= 0)
            {
                activated = false;
                lr.SetPosition(1, new Vector2(0, 0));
                touching = false;
            }
    } // end of update

    Camera FindCamera()
    {
        if (GetComponent<Camera>())
            return GetComponent<Camera>();
        else
            return Camera.main;
    }
}
