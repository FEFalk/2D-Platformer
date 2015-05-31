using System;
using UnityEngine;
using System.Collections;

public class ElevatorEnter : MonoBehaviour {

    public Material ElevatorOutside;
    public GameObject BlackBackground;
    public GameObject SpecialTextures;
    public GameObject ElevatorLights;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Player")
        {
            other.transform.Find("Body").transform.Find("Player_Body").GetComponent<SpriteRenderer>().sortingOrder = 3;
            other.transform.Find("Laser").GetComponent<LineRenderer>().sortingOrder = 2;
            BlackBackground.SetActive(true);
            SpecialTextures.SetActive(true);
            ElevatorLights.SetActive(true);
            Color oldColor = ElevatorOutside.color;
            ElevatorOutside.color = new Color(oldColor.r, oldColor.g, oldColor.b, 0.1f);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.Find("Body").transform.Find("Player_Body").GetComponent<SpriteRenderer>().sortingOrder = 0;
            other.transform.Find("Laser").GetComponent<LineRenderer>().sortingOrder = -1;
            BlackBackground.SetActive(false);
            SpecialTextures.SetActive(false);
            ElevatorLights.SetActive(false);
            Color oldColor = ElevatorOutside.color;
            ElevatorOutside.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1f);
        }
    }
}
