using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseProgramWindowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickedCancel()
    {
        this.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
