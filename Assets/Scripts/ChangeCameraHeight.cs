using UnityEngine;
using System.Collections;

public class ChangeCameraHeight : MonoBehaviour {

    public Camera mainCamera;
    public GameObject other;

    private bool wentUp = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            if (wentUp == false)
            {
                mainCamera.GetComponent<SmoothCamera2D>().height = 14f;
                wentUp = true;
                other.GetComponent<ChangeCameraHeight>().wentUp = true;
            }

            else
            {
                mainCamera.GetComponent<SmoothCamera2D>().height = 4f;
                wentUp = false;
                other.GetComponent<ChangeCameraHeight>().wentUp = false;
            }
        }
    }
}
