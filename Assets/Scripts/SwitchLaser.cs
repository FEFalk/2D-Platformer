using UnityEngine;
using System.Collections;

public class SwitchLaser : MonoBehaviour {

    public float laser = 0f;

    void Update()
    {
    }

    public void Switch(float newSpeed)
    {
        if (newSpeed == 0)
        {
            this.gameObject.GetComponent<GreenLaser>().enabled = false;
            this.gameObject.GetComponent<PlayerShoot>().enabled = true;
        }
        else if (newSpeed == 1)
        {
            this.gameObject.GetComponent<GreenLaser>().enabled = true;
            this.gameObject.GetComponent<PlayerShoot>().enabled = false;
        }
        else if (newSpeed == 2)
        {
            this.gameObject.GetComponent<GreenLaser>().enabled = false;
            this.gameObject.GetComponent<PlayerShoot>().enabled = false;
        }

    }
}
