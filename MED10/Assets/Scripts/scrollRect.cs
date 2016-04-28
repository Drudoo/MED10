using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrollRect : MonoBehaviour {

	public Text Scrolltext;
	public Transform startMarker;
	public Transform endMarker;
	public float speed;
	private float startTime;
	private float journeyLength;
	private Vector3 position;


	int checkCorrectAnswer = 0;
	int checkWrongAnswer = 0;
	int coins = 0;

	// Use this for initialization
	void Start () {
		Scrolltext.text = "Achievement: Hit all the Boxes!";
		speed = 0.2F;
	
	}
	
	// Update is called once per frame
	void Update () {


		transform.position = Vector3.Lerp(endMarker.position, startMarker.position, Mathf.PingPong(Time.time*speed,1.0f));


		if (checkCorrectAnswer < ApplicationModel.wrongAnswers) {

			Scrolltext.text = "Good job! Your last answer was correct. ";
			checkCorrectAnswer++;
			Debug.Log ("correct");

		} 

		if (checkWrongAnswer < ApplicationModel.wrongAnswers) {
			//checkWrongAnswer < ApplicationModel.wrongAnswers

			Scrolltext.text = "Wrong. Your last answer was incorrect.";
			checkWrongAnswer++;
			Debug.Log ("wrong");

		} 
		if(coins<ApplicationModel.coins){
			
			Scrolltext.text = "Hit all the Boxes!";
			coins++;

		}



}

}
