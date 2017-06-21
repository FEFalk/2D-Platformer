using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public Transform target;
    public float maxDistance;
    public float minDistance;
    public float height = 4f;
	Vector3 refVelocity = Vector3.zero;
	
	// Update is called once per frame
	void LateUpdate () 
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Clamp(target.position.x, minDistance, maxDistance), height, -10f), ref refVelocity, 0.2f);
	}

    public void changeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
