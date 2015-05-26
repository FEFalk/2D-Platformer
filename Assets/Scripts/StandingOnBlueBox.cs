using UnityEngine;
using System.Collections;

public class StandingOnBlueBox : MonoBehaviour {

    //If character collides with the platform, make it its child.
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player" || coll.gameObject.tag == "Blue Box")
             coll.gameObject.transform.parent = this.gameObject.transform;
    }
    //Once it leaves the platform, become a normal object again.
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Blue Box")
            coll.gameObject.transform.parent = null;
    }
}
