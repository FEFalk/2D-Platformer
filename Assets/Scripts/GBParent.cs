using UnityEngine;
using System.Collections;

public class GBParent : MonoBehaviour {
    public Component[] colliders;
    public Component[] greenLasers;
    public Component[] pikkadoller;
	public void enableCollider () {
        colliders = GetComponentsInChildren<CircleCollider2D>();
        foreach (CircleCollider2D collider in colliders) 
        {
            collider.GetComponent<CircleCollider2D>().enabled = true;
        }
	}
    public void enableGreenLasers()
    {
        greenLasers = GetComponentsInChildren<GreenLaser>();
        foreach (GreenLaser greenLaser in greenLasers)
        {
            greenLaser.GetComponent<GreenLaser>().enabled = true;
        }
    }
    public void disablegreenLasers()
    {
        greenLasers = GetComponentsInChildren<GreenLaser>();
        foreach (GreenLaser greenLaser in greenLasers)
        {
            greenLaser.GetComponent<GreenLaser>().enabled = false;
        }
    }
}
