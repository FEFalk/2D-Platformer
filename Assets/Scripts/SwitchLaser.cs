using UnityEngine;
using System.Collections;

public class SwitchLaser : MonoBehaviour {

    public GameObject Laser;
    public Material redLaser, greenLaser, blueLaser;
    void Update()
    {

    }

    public void Switch(float newSpeed)
    {
        if (newSpeed == 0)
        {

            if (GetComponent<PlayerShoot>().enabled == false && Laser.GetComponent<LineRenderer>().material != blueLaser)
            {
                Laser.GetComponent<LineRenderer>().material = blueLaser;
                GetComponent<GreenLaser>().enabled = false;
                GetComponent<PlayerShoot>().enabled = true;
                GetComponent<RedLaser>().enabled = false;
            }
            else if (GetComponent<PlayerShoot>().enabled == false)
            {
                GetComponent<GreenLaser>().enabled = false;
                GetComponent<PlayerShoot>().enabled = true;
                GetComponent<RedLaser>().enabled = false;
            }
        }

        else if (newSpeed == 1)
        {

            if (GetComponent<GreenLaser>().enabled == false && Laser.GetComponent<LineRenderer>().material != greenLaser)
            {
                Laser.GetComponent<LineRenderer>().material = greenLaser;
                GetComponent<GreenLaser>().enabled = true;
                GetComponent<PlayerShoot>().enabled = false;
                GetComponent<RedLaser>().enabled = false;
            }
            else if (GetComponent<GreenLaser>().enabled == false)
            {
                GetComponent<GreenLaser>().enabled = true;
                GetComponent<PlayerShoot>().enabled = false;
                GetComponent<RedLaser>().enabled = false;                
            }

        }
        else if (newSpeed == 2)
        {
            if (GetComponent<RedLaser>().enabled == false && Laser.GetComponent<LineRenderer>().material != redLaser)
            {
                Laser.GetComponent<LineRenderer>().material = redLaser;
                GetComponent<GreenLaser>().enabled = false;
                GetComponent<PlayerShoot>().enabled = false;
                GetComponent<RedLaser>().enabled = true;
            }
            else if (GetComponent<RedLaser>().enabled == false)
            {
                GetComponent<GreenLaser>().enabled = false;
                GetComponent<PlayerShoot>().enabled = false;
                GetComponent<RedLaser>().enabled = true;
            }
        }
    }
}
