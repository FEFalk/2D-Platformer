using UnityEngine;
using System.Collections;

public class ChangeCameraHeight : MonoBehaviour {

    public Camera mainCamera;

    private bool wentUp = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            if (wentUp == false)
            {
                mainCamera.GetComponent<SmoothCamera2D>().height = 15f;
                wentUp = true;
            }

            else
            {
                mainCamera.GetComponent<SmoothCamera2D>().height = 4f;
                wentUp = false;
            }
        }
    }
}
