using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchLaser : MonoBehaviour {

    public GameObject Laser;
    Slider slider;
    public Material redLaser, greenLaser, blueLaser;

    void Start()
    {
        slider = GameObject.Find("Slider").gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value == 0)
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

        else if (slider.value == 1)
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
        else if (slider.value == 2)
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
