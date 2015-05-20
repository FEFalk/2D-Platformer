using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour {
    public bool activated = false;
    void Update()
    {
        if (activated) 
        {
            Destroy(gameObject);
            activated = false;
        }
    }

}
