using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    public GameObject parentObject;
    public GameObject laserPrefab;
    public GameObject[] Buttons;
    public int rotationOffset = 0;
    private float scaling;

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    public bool dragging;

    private static RaycastHit2D hit;
    private LineRenderer lr;
    private bool obstacleButton = false;

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
    int ButtonCount = 0;

    void Start()
    {
        lr = laserPrefab.GetComponent<LineRenderer>();
        dragging = false;
        mainCamera = FindCamera();
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

        if ((Input.GetButton("Fire1") || Input.touchCount > 0) && isPointerOverGameObject == false)
        {
            if (dragging == false && touching == true)
                hit = Physics2D.Raycast(transform.position, transform.right * 100, 1 << LayerMask.NameToLayer("Ground"));
            else
                hit = Physics2D.Raycast(transform.position, -diff, 1 << LayerMask.NameToLayer("Ground"));

            //Debug.Log(hit.collider.tag);
            Debug.DrawRay(transform.position, transform.right * 100, Color.red);

            if (dragging == false && touching == true)
            {
                diff = new Vector2(transform.position.x - hit.point.x, transform.position.y - hit.point.y);
                lr.SetPosition(1, -diff);
            }

            if (hit.collider.tag == "ObstacleButton" && obstacleButton == false)
            {
                Debug.Log("Button.Length: " + Buttons.Length);
                 obstacleButton = true;
                Buttons[ButtonCount].GetComponent<ButtonHandler>().buttonActivate = true;
                ButtonCount++;
            }

            if (hit.collider.tag == "ResetButton" && obstacleButton == true)
            {
                Debug.Log("obstacleButton = false");
                obstacleButton = false;
            }


            //Debug.Log("Point: " + hit.point.x + ", " + hit.point.y + " -- Line: " + lr.transform.position.x + ", " + lr.transform.position.y);

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
            if (touching == true)
            {
                if (!hit.rigidbody)
                    return;
                if (hit.collider != null && hit.rigidbody.isKinematic == true)
                {
                    dragging = false;
                    return;
                }
                if (hit.collider != null && hit.rigidbody.isKinematic == false)
                {
                    if (hit.collider.tag == "Blue Box")
                    {
                        hit.collider.GetComponentInChildren<BoxEffects>().isActivated = true;
                        dragging = true;
                        diff = new Vector2(transform.position.x - hit.collider.transform.position.x, transform.position.y - hit.collider.transform.position.y);
                        lr.SetPosition(1, -diff);
                        if (!springJoint)
                        {
                            GameObject go = new GameObject("Rigidbody2D Dragger");
                            Rigidbody2D body = go.AddComponent<Rigidbody2D>() as Rigidbody2D;
                            springJoint = go.AddComponent<SpringJoint2D>() as SpringJoint2D;
                            body.isKinematic = true;
                            body.mass = 0.0001f;
                        }
                        springJoint.transform.position = hit.point;

                    }
                    else
                        dragging = false;

                    springJoint.distance = distance; // there is no distance in SpringJoint2D
                    springJoint.dampingRatio = damper;// there is no damper in SpringJoint2D but there is a dampingRatio
                    //springJoint.maxDistance = distance;  // there is no MaxDistance in the SpringJoint2D - but there is a 'distance' field
                    //  see http://docs.unity3d.com/Documentation/ScriptReference/SpringJoint2D.html
                    //springJoint.maxDistance = distance;
                    springJoint.connectedBody = hit.rigidbody;
                    // maybe check if the 'fraction' is normalised. See http://docs.unity3d.com/Documentation/ScriptReference/RaycastHit2D-fraction.html
                    if (dragging == true)
                        StartCoroutine("DragObject", hit.fraction);
                }

            }
        }
        else if (!Input.GetButton("Fire1") || Input.touchCount <= 0)
        {
            dragging = false;
            lr.SetPosition(1, new Vector2(0, 0));
            touching = false;
        }
        //Debug.Log ("Layermask: " + LayerMask.LayerToName (8));
        // I have proxy collider objects (empty gameobjects with a 2D Collider) as a child of a 3D rigidbody - simulating collisions between 2D and 3D objects
        // I therefore set any 'touchable' object to layer 8 and use the layerMask above for all touchable items
        
         // end of hit true condition
    } // end of update
    IEnumerator DragObject(float distance)
    {
        float oldDrag = springJoint.connectedBody.drag;
        float oldAngularDrag = springJoint.connectedBody.angularDrag;

        springJoint.connectedBody.drag = drag;
        springJoint.connectedBody.angularDrag = angularDrag;
        Camera mainCamera = FindCamera();



        while (Input.GetButton("Fire1") || Input.touchCount > 0)
        {
            if (hit.collider.tag != "Blue Box" || hit.rigidbody.isKinematic == true)
            {
                dragging = false;
                break;
            }
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            springJoint.transform.position = ray.GetPoint(distance);

            yield return null;
        }
        if (springJoint.connectedBody)
        {
            //Debug.Log(springJoint.connectedBody.rigidbody2D.velocity.ToString());
            Vector2 power = springJoint.connectedBody.GetComponent<Rigidbody2D>().velocity;
            power = power / (springJoint.connectedBody.GetComponent<Rigidbody2D>().mass + 1);
            //Debug.Log(power.ToString());

            springJoint.connectedBody.drag = 0.0f;//oldDrag;
            springJoint.connectedBody.angularDrag = 0.05f;//oldAngularDrag;
            springJoint.connectedBody = null;
        }
   }
    Camera FindCamera()
    {
        if (GetComponent<Camera>())
            return GetComponent<Camera>();
        else
            return Camera.main;
    }
}