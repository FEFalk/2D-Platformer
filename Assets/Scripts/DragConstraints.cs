using UnityEngine;
using System.Collections;

public class DragConstraints : MonoBehaviour {

    public bool activated=false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="ForceField")
        {
            activated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "ForceField")
        {
            activated = false;
        }
    }
}
