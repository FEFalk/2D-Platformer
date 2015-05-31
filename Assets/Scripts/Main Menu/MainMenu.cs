using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isQuit;

    void Update()
    {
        if (EventSystem.current.currentInputModule is TouchInputModule)
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
}
