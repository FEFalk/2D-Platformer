using UnityEngine;
using System.Collections;

public class GBParent : MonoBehaviour {
    public Component[] colliders;
    public Component[] pikkadoller;
    public GameObject[] buttons;
    public GameObject player;
    public Component[] greenLasers;
    public Component[] blueLasers;
    public Component[] redLasers;
    public int cur = 0;
    public int buttonSize;

	public void enableCollider () {
        colliders = GetComponentsInChildren<CircleCollider2D>();
        foreach (CircleCollider2D collider in colliders) 
        {
            collider.enabled = true;
        }
	}
    public void enableGreenLasers()
    {

        if (cur == 0)
        {
            blueLasers = GetComponentsInChildren<PlayerShoot>();
            foreach (PlayerShoot blueLaser in blueLasers)
            {
                blueLaser.enabled = true;
            }
        }

        else if (cur == 1)
        {
            greenLasers = GetComponentsInChildren<GreenLaser>();
            foreach (GreenLaser greenLaser in greenLasers)
            {
                greenLaser.enabled = true;
            }
        }

        else if (cur == 2)
        {
            redLasers = GetComponentsInChildren<RedLaser>();
            foreach (RedLaser redLaser in redLasers)
            {
                redLaser.enabled = true;
            }
        }
    }

    public void disablegreenLasers()
    {
        if (cur == 0)
        {
            blueLasers = GetComponentsInChildren<PlayerShoot>();
            foreach (PlayerShoot blueLaser in blueLasers)
            {
                blueLaser.enabled = false;
            }
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<RedLaser>().enabled = false;
        }
        else if (cur == 1)
        {
            greenLasers = GetComponentsInChildren<GreenLaser>();
            foreach (GreenLaser greenLaser in greenLasers)
            {
                greenLaser.enabled = false;
            }
        }

        else if (cur == 2)
        {
            redLasers = GetComponentsInChildren<RedLaser>();
            foreach (RedLaser redLaser in redLasers)
            {
                redLaser.enabled = false;
            }
        }
    }

    public void disablePikkadollz()
    {
        for (int i = 0; i < buttonSize; i++)
            buttons[i].transform.Find("Pikkadoll").gameObject.SetActive(false);
    }
}
