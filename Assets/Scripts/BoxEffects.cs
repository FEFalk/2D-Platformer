using UnityEngine;
using System.Collections;

public class BoxEffects : MonoBehaviour {
    public bool isActivated = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (isActivated == true)
            transform.Find("BoxEffects").gameObject.SetActive(true);
        else
            transform.Find("BoxEffects").gameObject.SetActive(false);

        isActivated = false;
	}
}
