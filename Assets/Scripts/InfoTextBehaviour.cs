using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextBehaviour : MonoBehaviour {

    Text text;
    Image image;

	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();
        image = this.GetComponent<Image>();
	}
	


	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Toggles image and text enable in infotext
    /// </summary>
    public void Clicked()
    {
        text.enabled = !text.enabled;
        //image.enabled = !image.enabled;
    }
}
