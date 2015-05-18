using UnityEngine;
using System.Collections;



public class LaserMovement : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {


            //float distanceY = Mathf.Abs(hit.point.y - transform.position.y);
            //float distanceX = Mathf.Abs(hit.point.x - transform.position.x);
            //Vector2 point = new Vector2(distanceX, distanceY);

            
        }
        else if (!Input.GetButton("Fire1"))
        {

        }



        //if (!Input.GetButton("Fire1"))
        //{

            
        //}

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.tag!="Player")
    //        hit = true;
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    hit = false;
    //}
}