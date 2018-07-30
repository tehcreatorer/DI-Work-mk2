using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoPopUp : MonoBehaviour {

    public GameObject image;
    public GameObject indicator;
    public GameObject nextIndicator;
    private StoryEngineMono storyEngine;
    public StoryEngine.Location thisLocation;
    public int nextLocationInt;
    public bool nextIndicatorBool;

	// Use this for initialization
	void Start () {
        storyEngine = GameObject.FindGameObjectWithTag("StoryEngine").GetComponent<StoryEngineMono>();
        image.SetActive(false);
        indicator.SetActive(true);
        nextIndicator.SetActive(storyEngine.AdviceIndex() == (int)thisLocation);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        nextLocationInt = storyEngine.nextLocationAdviceInt;

        if (storyEngine.AdviceIndex() == (int)thisLocation)
        {
            nextIndicatorBool = true;
            nextIndicator.SetActive(true);
        }
        else
        {
            nextIndicatorBool = false;
            nextIndicator.SetActive(false);
        }
        */
	}

    public void UpdateIndicator(int index)
    {
        nextLocationInt = index;

        if (index == (int)thisLocation)
        {
            nextIndicatorBool = true;
            nextIndicator.SetActive(true);
        }
        else
        {
            nextIndicatorBool = false;
            nextIndicator.SetActive(false);
        }
    }

    public void OnClicked()
    {
        
        image.SetActive(!image.activeSelf);
        indicator.SetActive(!indicator.activeSelf);
        
        /*
         * //old code
        gameObject.GetComponentInChildren<MapInfoPopUpImage>().gameObject.SetActive(!gameObject.GetComponentInChildren<MapInfoPopUpImage>().gameObject.activeSelf);
        gameObject.GetComponentInChildren<MapInfoPopUpIndicator>().gameObject.SetActive(!gameObject.GetComponentInChildren<MapInfoPopUpIndicator>().gameObject.activeSelf);
        */
    }
}
