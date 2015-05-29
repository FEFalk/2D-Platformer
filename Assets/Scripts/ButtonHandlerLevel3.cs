using UnityEngine;
using System.Collections;

public class ButtonHandlerLevel3 : MonoBehaviour {
    public GameObject Object;
    public GameObject Obstacle;
    public bool buttonActivate = false;
    public bool greenButtonActivate = false;
    private bool obstacle = false;
    // Update is called once per frame
    void Update()
    {

        if (buttonActivate && obstacle == false)
        {
            Obstacle.GetComponent<ObstacleHandler>().activated = true;
            buttonActivate = false;
            obstacle = true;
        }

        if (greenButtonActivate && Object != null)
        {
            greenButtonActivate = false;
        }
        else if (greenButtonActivate)
        {
            greenButtonActivate = false;
        }
    }
}
