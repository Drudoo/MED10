﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class aspectRatio : MonoBehaviour {

	private float aspectX;
	private float aspectY;
	public bool square;
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		if (!square) {
			aspectX = 16f;
			aspectY = 9f;
		} else {
			aspectX = 4f;
			aspectY = 3f;
		}
		// set the desired aspect ratio
		float targetaspect = aspectX / aspectY;
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		if (scaleheight < 1.0f)
	    {
	        Rect rect = camera.rect;

	        rect.width = 1.0f;
	        rect.height = scaleheight;
	        rect.x = 0;
	        rect.y = (1.0f - scaleheight) / 2.0f;

	        camera.rect = rect;
	    }
	    else // add pillarbox
	    {
	        float scalewidth = 1.0f / scaleheight;

	        Rect rect = camera.rect;

	        rect.width = scalewidth;
	        rect.height = 1.0f;
	        rect.x = (1.0f - scalewidth) / 2.0f;
	        rect.y = 0;

	        camera.rect = rect;
	    }
	}

}
