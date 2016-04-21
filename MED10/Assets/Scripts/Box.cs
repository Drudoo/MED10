using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	public bool hit = false;
	//public Texture2D myTexture;
	public Material questionBoxMat;

	//float direction;

	void Start() {

		//questionBoxMat = Resources.Load ("Materials/" + questionBoxUsed") as Material;


	}

	void Update() {

		if (hit) {
			//this.GetComponent<Renderer>().material.mainTexture = myTexture;
			this.GetComponent<Renderer>().material = questionBoxMat;
		}
	


	}

}
