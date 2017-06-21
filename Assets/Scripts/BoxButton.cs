using UnityEngine;
using System.Collections;

public class BoxButton : MonoBehaviour {

    public GameObject Object;
    bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Blue Box")
        {
            transform.Find("ButtonEffects").gameObject.SetActive(true);
            transform.Find("buttonRed").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/buttonRed_pressed");
            if (!Object.GetComponent<Elevator2>())
            {
                Object.GetComponent<Animator>().SetBool("Activated", true);

            }
            else
                Object.GetComponent<Elevator2>().activated = true;

        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Blue Box")
        {
            transform.Find("ButtonEffects").gameObject.SetActive(false);
            transform.Find("buttonRed").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/buttonRed");
            if (!Object.GetComponent<Elevator2>())
            {
                Object.GetComponent<Animator>().SetBool("Activated", false);

            }

        }
    }

}
