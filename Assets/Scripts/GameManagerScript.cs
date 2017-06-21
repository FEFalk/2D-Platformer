using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static int currentLevel = 0;
	public static int unlockLevel;

	public static void CompleteLevel()
	{
		currentLevel += 1;
        if (currentLevel == 4)
            currentLevel = 0;

		Application.LoadLevel(currentLevel);
	}
    public void StartButton(bool start)
    {
        if (start == true)
        {
            CompleteLevel();
        }
    }
    public void QuitButton(bool quit)
    {
        if (quit == true)
        {
            Application.Quit();
        }
    }

    public void LoadSelected(int index)
    {
        currentLevel = index;
        Application.LoadLevel(index);
    }
}

