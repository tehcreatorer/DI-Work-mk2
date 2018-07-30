using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryEngine {

    public enum Location { NoLocation, Porrasaula, MRLabra, Terveysteknologia, SulautettuElektroniikka, DataAnalytiikkaJaTekoaly, Ohjelmistotekniikka, Oppimisanalytiikka, Kieliteknologia, MantyJaHonka, Kahvihuone }

    /*
    public GameObject storyEngineObj;


    Location lastLocation;
    Location previousLocation;


	// Use this for initialization
	void Start () {
        storyEngineObj = GameObject.FindGameObjectWithTag("StoryEngine");
        lastLocation = storyEngineObj.GetComponent<StoryEngineMono>().lastLocation;
        previousLocation = storyEngineObj.GetComponent<StoryEngineMono>().previousLocation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */

    #region old
        /*
    /// <summary>
    /// Returns text for the needed location
    /// </summary>
    /// <returns></returns>
    public string CreateInfoText(Location loc)
    {
        
        //updates location
        //Last change in evening
        if (lastLocation == Location.NoLocation)
        {
            if (loc != lastLocation) {
                previousLocation = lastLocation;
                lastLocation = loc;
            }
        }

        //Temp text
        string createdText = "";


        int l = (int)lastLocation;
        int p = (int)previousLocation;


        //Pre text
        switch (p)
        {
            case 0:
                {
                    createdText += "NoLocation";
                    break;
                }
            case 1:
                {
                    createdText += "Pre 0";
                    break;
                }
            case 2:
                {
                    createdText += "Pre 1";
                    break;
                }
            default:
                {
                    createdText += "Pre default";
                    break;
                }

        }

        //Main body of text
        switch (l)
        {

                //building case
            case 0:
                {
                    createdText += "NoLocation";
                    break;
                }

                //Tree case
            case 1:
                {
                    createdText += " Main Body 0";
                    break;
                }

            case 2:
                {
                    createdText += " Main Body 1";
                    break;
                }

            default:
                {
                    createdText += " Main Body default";
                    break;
                }


        }

        return createdText;
        
        //return "Test text StoryEngine.";
    }

    public void UpdateLocation(Location loc)
    {
        if(loc != lastLocation)
        {
            previousLocation = lastLocation;
            lastLocation = loc;
        }



    }
    */
    #endregion

}
