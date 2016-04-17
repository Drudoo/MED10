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

	private Collider2D _col;

	void Start () {
		buttonStartPosition = button.transform.localPosition;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Player" && !questionAsked) {
			_col = col;
			askQuestion.showQuestion();
			questionAsked = true;

		}
	}

	void Update() {
		if (questionAsked) {
			if (askQuestion.correct) {
				DepressButton(_col.transform.localScale.x);
			} else {
				Debug.Log("Wrong Answer");
			}
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
