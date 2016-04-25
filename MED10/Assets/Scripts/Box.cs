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

	public AskQuestion askQuestion;

	public AudioClip audio;

	public bool didHit = false;

	//float direction;

	void Start() {

		//questionBoxMat = Resources.Load ("Materials/" + questionBoxUsed") as Material;
		coins = true;
		//count = 0;




	}

	void Update() {

		if (hit) {
			//this.GetComponent<Renderer>().material.mainTexture = myTexture;
			this.GetComponent<Renderer>().material = questionBoxMat;

			hit = false;

			//updateScore();
			if (askQuestion.isCoin) {

				if (coins) {
					if (ApplicationModel.soundOn) {
						GetComponent<AudioSource>().clip = audio;
				        GetComponent<AudioSource>().loop = false;
				        GetComponent<AudioSource>().Play();
					}

					Instantiate (coin, transform.position, Quaternion.identity);
					coins= false;

				}
			}

		}


	}


}
