using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	public bool hit = false;
	//public Texture2D myTexture;
	public Material questionBoxMat;
	public GameObject coin;
	public bool coins = true;
	private int count = 0;
	public int scoreValue = 1;




	//float direction;

	void Start() {

		//questionBoxMat = Resources.Load ("Materials/" + questionBoxUsed") as Material;
		coins = true;
		//count = 0;




	}

	void Update() {
		
		if (hit) {
			//this.GetComponent<Renderer>().material.mainTexture = myTexture;
		
			//updateScore();

			this.GetComponent<Renderer>().material = questionBoxMat;

			if (coins) {
				Instantiate (coin, transform.position, Quaternion.identity);
				coins= false;
			
			}
			hit = false;

		}

	
	}
		

}
