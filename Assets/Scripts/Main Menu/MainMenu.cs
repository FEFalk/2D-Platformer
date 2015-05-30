using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isQuit;

    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel(1);
            GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (isQuit)
            Application.Quit();
    }
}
