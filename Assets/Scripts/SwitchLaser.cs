using UnityEngine;
using System.Collections;

public class SwitchLaser : MonoBehaviour {

    public GameObject Pikkadoll;
    public Material redLaser, greenLaser, blueLaser;
    void Update()
    {

    }

    public void Switch(float newSpeed)
    {
        GameObject Laser = transform.parent.gameObject.transform.Find("Laser").gameObject;
        if (newSpeed == 0)
        {

            if (Pikkadoll.GetComponent<PlayerShoot>().enabled == false && Laser.GetComponent<LineRenderer>().material != blueLaser)
            {
                Laser.GetComponent<LineRenderer>().material = blueLaser;
                Pikkadoll.GetComponent<GreenLaser>().enabled = false;
                Pikkadoll.GetComponent<PlayerShoot>().enabled = true;
                Pikkadoll.GetComponent<RedLaser>().enabled = false;
            }
            else if (Pikkadoll.GetComponent<PlayerShoot>().enabled == false)
            {
                Pikkadoll.GetComponent<GreenLaser>().enabled = false;
                Pikkadoll.GetComponent<PlayerShoot>().enabled = true;
                Pikkadoll.GetComponent<RedLaser>().enabled = false;
            }
        }

        else if (newSpeed == 1)
        {

            if (Pikkadoll.GetComponent<GreenLaser>().enabled == false && Laser.GetComponent<LineRenderer>().material != greenLaser)
            {
                Laser.GetComponent<LineRenderer>().material = greenLaser;
                Pikkadoll.GetComponent<GreenLaser>().enabled = true;
                Pikkadoll.GetComponent<PlayerShoot>().enabled = false;
                Pikkadoll.GetComponent<RedLaser>().enabled = false;
            }
            else if (Pikkadoll.GetComponent<GreenLaser>().enabled == false)
            {
                Pikkadoll.GetComponent<GreenLaser>().enabled = true;
                Pikkadoll.GetComponent<PlayerShoot>().enabled = false;
                Pikkadoll.GetComponent<RedLaser>().enabled = false;                
            }

        }
        else if (newSpeed == 2)
        {
            if (Pikkadoll.GetComponent<RedLaser>().enabled == false && Laser.GetComponent<LineRenderer>().material != redLaser)
            {
                Laser.GetComponent<LineRenderer>().material = redLaser;
                Pikkadoll.GetComponent<GreenLaser>().enabled = false;
                Pikkadoll.GetComponent<PlayerShoot>().enabled = false;
                Pikkadoll.GetComponent<RedLaser>().enabled = true;
            }
            else if (GetComponent<RedLaser>().enabled == false)
            {
                Pikkadoll.GetComponent<GreenLaser>().enabled = false;
                Pikkadoll.GetComponent<PlayerShoot>().enabled = false;
                Pikkadoll.GetComponent<RedLaser>().enabled = true;
            }
        }
    }
}
