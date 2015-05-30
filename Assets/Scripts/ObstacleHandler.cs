using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour {
    public bool activated = false;
    public GameObject AlarmLights;

    void Update()
    {
        if (activated) 
        {
            StartCoroutine(Activate());

        }
    }

    IEnumerator Activate()
    {
        GetComponent<Animator>().enabled = true;
        AlarmLights.SetActive(true);
        GameObject.Find("GameManager").transform.Find("Alarm").GetComponent<AudioSource>().enabled = true;
        AlarmLights.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);
        GetComponent<Collider2D>().enabled = false;
        
        GameObject.Find("WindowBackground").gameObject.GetComponent<Animator>().enabled = true;
        activated = false;

        GameObject.Find("GameManager").gameObject.GetComponent<AudioSource>().Play();
        
    }
}
