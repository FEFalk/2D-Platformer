using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public void StartButton()
    {
         Application.LoadLevel(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
