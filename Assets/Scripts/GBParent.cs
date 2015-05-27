using UnityEngine;
using System.Collections;

public class GBParent : MonoBehaviour {
    public Component[] colliders;
    public Component[] greenLasers;
    public GameObject[] buttons;
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
    public void disablePikkadoller()
    {
        for (int i = 0; i < buttonSize; i++)
        {
            buttons[i].transform.Find("Pikkadoll").gameObject.SetActive(false);
        }
    }
}
