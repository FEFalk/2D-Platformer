using UnityEngine;
using System.Collections;

public class GBParent : MonoBehaviour {
    private CircleCollider2D[] colliders;
    private GreenLaser[] greenLasers;
    private BlueLaser[] blueLasers;
    private RedLaser[] redLasers;
    private LineRenderer[] laserRenderers;
    private SwitchLaser[] switchLasers;
    public GameObject[] buttons;
    public int buttonSize;

	public void enableCollider () 
    {
        colliders = GetComponentsInChildren<CircleCollider2D>();
        foreach (CircleCollider2D collider in colliders) 
        {
            collider.enabled = true;
        }
	}
    public void enableGreenLasers()
    {
        greenLasers = GetComponentsInChildren<GreenLaser>();
        foreach (GreenLaser greenLaser in greenLasers)
        {
            greenLaser.enabled = true;
        }
        switchLasers = GetComponentsInChildren<SwitchLaser>();
        foreach (SwitchLaser switchLaser in switchLasers)
        {
            switchLaser.enabled = true;
        }
    }
    public void disableLasers()
    {
        greenLasers = GetComponentsInChildren<GreenLaser>();
        foreach (GreenLaser greenLaser in greenLasers)
        {
            greenLaser.enabled = false;
        }
        blueLasers = GetComponentsInChildren<BlueLaser>();
        foreach (BlueLaser blueLaser in blueLasers)
        {
            blueLaser.enabled = false;
        }
        redLasers = GetComponentsInChildren<RedLaser>();
        foreach (RedLaser redLaser in redLasers)
        {
            redLaser.enabled = false;
        }
    }
    public void disablePikkadollz()
    {
        for (int i = 0; i < buttonSize; i++)
            buttons[i].transform.Find("Pikkadoll").gameObject.SetActive(false);
    }
    public void resetLasers()
    {
        for (int i = 0; i < buttonSize; i++)
        {
            buttons[i].transform.Find("Pikkadoll").transform.Find("Laser").GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 0));
            buttons[i].transform.Find("ButtonEffects").gameObject.SetActive(false);
        }

    }

}
