using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static int currentLevel = 1;
	public static int unlockLevel;

	public static void CompleteLevel()
	{
		currentLevel += 1;
		Application.LoadLevel(currentLevel);
	}
}

