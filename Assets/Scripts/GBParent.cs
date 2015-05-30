using UnityEngine;
using System.Collections;

public class GBParent : MonoBehaviour {
    private CircleCollider2D[] colliders;
    private GreenLaser[] greenLasers;
    private LineRenderer[] laserRenderers;
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
    }
    public void disablegreenLasers()
    {
        greenLasers = GetComponentsInChildren<GreenLaser>();
        foreach (GreenLaser greenLaser in greenLasers)
        {
            greenLaser.enabled = false;
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
