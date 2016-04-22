using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	public bool hit = false;

	public Material questionBoxMat;
	public AskQuestion askQuestion;
	private bool questionAsked = false;

	private string device = "";

	void Start() {
		#if UNITY_EDITOR
			device = "UNITY_EDITOR";
		#endif

		if (device == "") {
			#if UNITY_ANDROID
				device = "UNITY_ANDROID";
			#endif
		}
	}

	void Update() {

		if (hit && !questionAsked) {
			this.GetComponent<Renderer>().material = questionBoxMat;
			if (device == "UNITY_ANDROID") {
				if (!questionAsked && !askQuestion.isCoin) {
					askQuestion.showQuestion();
				}
			} else {
				Debug.Log(askQuestion.isCoin?"I am a coin":("Question: " + askQuestion.mTitle));
			}
			questionAsked = true;
		}
	}
}
