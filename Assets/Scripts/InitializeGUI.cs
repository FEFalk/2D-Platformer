using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitializeGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject RightButton, LeftButton, CancelButton, JumpButton, Slider;
        RightButton = transform.Find("RightButton").gameObject;
        LeftButton = transform.Find("LeftButton").gameObject;
        CancelButton = transform.Find("CancelButton").gameObject;
        JumpButton = transform.Find("JumpButton").gameObject;

        RightButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_ButtonMove");
        LeftButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_ButtonMove");
        CancelButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_ButtonCancel");

        transform.Find("Slider/Handle Slide Area/Handle").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_SwitchLaser2");
        transform.Find("Slider/Background").gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_SwitchLaserFocused");

        LeftButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_ButtonMove");
        CancelButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("GUI/Unity_ButtonCancel");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
