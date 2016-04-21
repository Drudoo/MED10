using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public float ScaleToDepress = 1f;
	public GameObject button;
	private Vector3 buttonStartPosition;
	public Controller2D player;
	public AskQuestion askQuestion;
	public bool Activated = false;

	private bool questionAsked = false;

	private string device = "";

	private Collider2D _col;

	void Start () {
		buttonStartPosition = button.transform.localPosition;
		#if UNITY_EDITOR
			device = "UNITY_EDITOR";
    	#endif

		if (device == "") {
			#if UNITY_ANDROID
				device = "UNITY_ANDROID";
			#endif
		}

		//Debug.Log("Device: " + device);

	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Player") {
			_col = col;
			if (device == "UNITY_EDITOR") {
				DepressButton(col.transform.localScale.x);
			} else if (device == "UNITY_ANDROID") {
				if (!questionAsked) {
					askQuestion.showQuestion();
				}
				questionAsked = true;
			}
		}
	}

	void Update() {
		if (device == "UNITY_ANDROID") {
			if (askQuestion.correct) {
				DepressButton(_col.transform.localScale.x);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Player" && questionAsked && !askQuestion.correct) {

			questionAsked = false;
		}
	}


	private void DepressButton(float scale) {

		if (scale >= ScaleToDepress && Vector3.Distance(button.transform.localPosition, buttonStartPosition) < 0.4f) {
			button.transform.Translate(0f,-1f*Time.deltaTime,0f);
		}

		if (Vector3.Distance(button.transform.localPosition,buttonStartPosition)> 0.3f) {
			Activated = true;
		}
	}
}
