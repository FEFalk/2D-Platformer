using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static int currentLevel = 0;
	public static int unlockLevel;
    public int health = 1;
   
    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health--;
    }

	public static void CompleteLevel()
	{
		currentLevel += 1;
		Application.LoadLevel(currentLevel);
	}
    void Update () {
        if (health <= 0)
        {
            Die();
        }
	}
    void Die()
    {
        Destroy(gameObject);
    }
}

