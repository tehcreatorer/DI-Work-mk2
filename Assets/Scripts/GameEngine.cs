using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

    public GameObject mapObject;
    public GameObject closeProgramWindow;
    public StoryEngineMono storyEngineInstance;
    public GameObject mapCanvas;
    private Text mapFactoidText;
    private string selectedFactoid;
    private string selectedLocationAdvice;
    //public GameObject cameraObject;

    private float buttonCooldownTime = 2.0f;
    private float currentCooldownTime = 0.0f;

	// Use this for initialization
	void Start () {
        mapObject.SetActive(false);
        storyEngineInstance = GameObject.FindGameObjectWithTag("StoryEngine").GetComponent<StoryEngineMono>();
        mapCanvas = GameObject.FindGameObjectWithTag("MapCanvas");

        //cameraObject.SetActive(true);
        //RandomizeFactoidText();
        SetNextLocationText();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(closeProgramWindow.activeSelf == true)
            {
                closeProgramWindow.SetActive(false);
            }
            else
            {
                closeProgramWindow.SetActive(true);
            }
        }

#if UNITY_ANDROID
        if (Input.deviceOrientation == DeviceOrientation.FaceUp)
        {
            if (mapObject.activeSelf == false)//replaced active with activeSelf
            {
                mapObject.SetActive(true);
                mapFactoidText = GameObject.FindGameObjectWithTag("FactoidText").GetComponent<Text>();
                //mapFactoidText.text = selectedFactoid;
                mapFactoidText.text = selectedLocationAdvice;
                //mapCanvas.GetComponent<MapCanvasScript>().UpdateAdviceIndex(storyEngineInstance.nextLocationAdviceInt); //not working now
            }
        }
        else
        {
            if(mapObject.activeSelf == true)//replaced active with activeSelf
            {
                mapObject.SetActive(false);
            }
        }
#endif


#if UNITY_EDITOR
        
        #region testing_inputs
        
        if (Input.GetKeyDown(KeyCode.F5))
        {
            //storyEngineInstance.DebugPrint();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            Debug.Log("F9 Pressed. Non Functional.");
        }

        //Doesn't work as intended
        if (Input.GetKey(KeyCode.M))
        {
            #region old
            //mapObject.SetActive(!mapObject.activeSelf);
            /*
            if (mapObject.activeSelf == false)
            {
                    mapObject.SetActive(true);
            }
            else
            {
                    mapObject.SetActive(false);
            }
            */
            #endregion
            mapObject.SetActive(!mapObject.activeSelf);
            mapFactoidText = GameObject.FindGameObjectWithTag("FactoidText").GetComponent<Text>();
            mapFactoidText.text = selectedFactoid;
           
            //mapCanvas.GetComponent<MapCanvasScript>().UpdateAdviceIndex(storyEngineInstance.nextLocationAdviceInt); //now working now

        }
        /*
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        */

        currentCooldownTime -= Time.deltaTime;
        //Debug.Log(string.Format("{0:N4}", currentCooldownTime));
        #endregion
#endif
    }

    //Sets Map Screens random factoid. obsolete now
    public void RandomizeFactoidText()
    {
        string factoid = storyEngineInstance.factoids[Random.Range(0, storyEngineInstance.factoids.Length - 1)];
        selectedFactoid = factoid;
    }

    //Sets maps screen next location advice text
    //Doesn't seem to set the text. ***Requires Debugging***
    public void SetNextLocationText()
    {
        string advice = storyEngineInstance.locationAdvice[storyEngineInstance.nextLocationAdviceInt];
        selectedLocationAdvice = advice;
    }
}
