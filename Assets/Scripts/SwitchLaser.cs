using UnityEngine;
using System.Collections;

public class SwitchLaser : MonoBehaviour {

    public GameObject currentLaser;

    void Update()
    {
    }

    public void Switch(float newSpeed)
    {
        if (newSpeed == 0)
        {
            if (GetComponent<GreenLaser>().touching == false)
            {
                GetComponent<GreenLaser>().enabled = false;
                GetComponent<PlayerShoot>().enabled = true;
            }
            if (currentLaser != null)
            {
                if (currentLaser.GetComponent<GreenLaser>().touching == false)
                {
                    currentLaser.GetComponent<GreenLaser>().enabled = false;
                    currentLaser.GetComponent<PlayerShoot>().enabled = true;
                }
            }
        }

        else if (newSpeed == 1)
        {
            if (GetComponent<GreenLaser>().touching == false)
            {
                GetComponent<GreenLaser>().enabled = true;
                GetComponent<PlayerShoot>().enabled = false;
            }
            if (currentLaser != null)
            {
                if (currentLaser.GetComponent<GreenLaser>().touching == false)
                {
                    currentLaser.GetComponent<GreenLaser>().enabled = true;
                    currentLaser.GetComponent<PlayerShoot>().enabled = false;
                }
            }

        }
        else if (newSpeed == 2)
        {
            if (GetComponent<GreenLaser>().touching == false)
            {
                this.gameObject.GetComponent<GreenLaser>().enabled = false;
                this.gameObject.GetComponent<PlayerShoot>().enabled = false;
            }

            currentLaser.GetComponent<GreenLaser>().enabled = false;
            currentLaser.GetComponent<PlayerShoot>().enabled = false;
        }

    }
}
