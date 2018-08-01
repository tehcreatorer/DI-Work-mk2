/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class CustomTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
        private TrackableBehaviour mTrackableBehaviour;
        private GameObject storyEngine;
        public StoryEngine.Location trackableLocation;
        public GameObject trackableCanvas;
        private GameEngine gameEngineInstance;
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            storyEngine = GameObject.FindGameObjectWithTag("StoryEngine");
            gameEngineInstance = GameObject.FindGameObjectWithTag("GameEngine").GetComponent<GameEngine>();
            //Debug.Log("Start Test");
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            //Canvas canvas = GetComponentInChildren<Canvas>();
            //canvas.gameObject.SetActive(false);
            //GetComponentInChildren<Canvas>().gameObject.SetActive(false);

        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            //Debug.Log("Before if statement");

            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                //Debug.Log("State Changed debug");
                //trackableCanvas.GetComponent<Canvas>().enabled = true;
                trackableCanvas.SetActive(true);
                OnTrackingFound();
                
                //Debug.Log("State Changed debug");
            }
            else
            {
                trackableCanvas.SetActive(false);
                OnTrackingLost();
            }
            //Debug.Log("After If Statement");
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS

        private void OnTrackingFound()
        {

            //Debug.Log("Test Text Debug.");
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            
            //Canvas canvas = GetComponentInChildren<Canvas>();

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
                
            }

            //Enables canvas

            //GetComponentInChildren<Canvas>().gameObject.SetActive(true);
            //GetComponentInChildren<Text>().text = engine.CreateInfoText(trackableLocation);
            //GetComponentInChildren<ImageTargetTextScript>().gameObject.GetComponent<Text>().text = "Test Text debug.";
     
            GetComponentInChildren<ImageTargetTextScript>().gameObject.GetComponent<Text>().text = storyEngine.GetComponent<StoryEngineMono>().CreateInfoText(trackableLocation);
            //gameEngineInstance.RandomizeFactoidText(); //old factoid implementation
            gameEngineInstance.SetNextLocationText();
            Debug.Log("Test Text Debug.");

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }



        private void OnTrackingLost()
        {
            //Debug.Log("Start of TrackingLost");
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            //Canvas canvas = GetComponentInChildren<Canvas>();
            //Disable canvas
            //canvas.enabled = false;

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            //Debug.Log("End of tracking lost");
        }

        #endregion // PRIVATE_METHODS
    }

}
