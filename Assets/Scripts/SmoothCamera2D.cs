using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public Transform target;
    public float maxDistance;
    public float minDistance;
	Vector3 refVelocity = Vector3.zero;
	
	// Update is called once per frame
	void LateUpdate () 
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Clamp(target.position.x, minDistance, maxDistance), target.position.y + 4f, -10f), ref refVelocity, 0.2f);
	}
}
